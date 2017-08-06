using Home.Application.Chat;
using Home.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Home.Hubs
{
    public class Chat : Microsoft.AspNet.SignalR.Hub
    {
        private readonly IChatApp _chatApp;

        public Chat()
        {
            _chatApp = DependencyResolver.Current.GetService<IChatApp>();
        }

        public static List<Usuario> Usuarios = new List<Usuario>();

        public void Conectar(Usuario usuario)
        {
            // Verificando se usuário existe em memória
            var user = Usuarios.FirstOrDefault(x => x.Id == usuario.Id);

            // Adicionando connection Id no usuário
            usuario.ConnectionIds.Add(Context.ConnectionId);

            // Caso este usuário não exista em memória, adicionar
            if (user == null)
                Usuarios.Add(usuario);

            // Caso já existir em memória, adicionar nova connection Id no usuário em memória
            else if (user.ConnectionIds.All(x => x != Context.ConnectionId))
                user.ConnectionIds.Add(Context.ConnectionId);

            // Atualizando usuário online em todos os clientes
            if (Usuarios.FirstOrDefault(x => x.Id == usuario.Id)?.ConnectionIds.Count() == 1)
                Clients.All.AtualizaNovoUsuarioOnline(usuario);

            // Montando lista dos usuários onlines para o usuário que acabou de entrar
            Clients.Caller.MontaListaLogados(Usuarios);
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            // Verificando se a conexão está ativa em algum usuário da lista em memória
            var user = Usuarios.First(x => x.ConnectionIds.Any(y => y == Context.ConnectionId));

            // Removendo conexão da lista em memória
            user.ConnectionIds.Remove(Context.ConnectionId);

            // Caso não tenha mais nenhuma conexão ativa remove usuário da memória
            if (!user.ConnectionIds.Any())
            {
                Usuarios.Remove(user);
                Clients.All.RemoverUsuarioChat(user);
            }

            return base.OnDisconnected(stopCalled);
        }

        public void EnviarMensagem(Usuario usuarioEnvio, int idUsuarioDestino, string mensagem)
        {
            // Procurando todas as conexões dos usuários da conversa
            var listaUsuarios = Usuarios.Where(x => x.Id == usuarioEnvio.Id || x.Id == idUsuarioDestino);
            var connectionIds = new List<string>();

            foreach (var usuario in listaUsuarios)
                connectionIds.AddRange(usuario.ConnectionIds);

            // Transmitindo mensagem para todos os usuários da conversa
            Clients.Clients(connectionIds).TransmitirMensagem(usuarioEnvio, idUsuarioDestino, mensagem);

            // Verificando se usuário destino está online para gravar data de recebimento
            DateTime? dataRecebimento = null;
            if (Usuarios.Any(x => x.Id == idUsuarioDestino))
                dataRecebimento = DateTime.Today;

            // Salvando mensagem na base de dados
            _chatApp.Post(new Mensagem(mensagem, usuarioEnvio, idUsuarioDestino, dataRecebimento));
        }

        public void MarcarComoVisualizada(int idUsuarioLogado, int idUsuarioEnvio)
        {
            // Instanciando objeto de mensagem
            var mensagem = new Mensagem
            {
                UsuarioEnvio = new Usuario { Id = idUsuarioEnvio },
                UsuarioDestino = new Usuario { Id = idUsuarioLogado },
                DataVisualizacao = DateTime.Today,
                DataRecebimento = DateTime.Today
            };

            // Gravando mensagem como visualizada
            _chatApp.Put(mensagem);
        }
    }
}   