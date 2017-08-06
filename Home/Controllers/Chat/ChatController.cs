using Home.Application.Chat;
using Home.Infra;
using Home.Models.Dto;
using Home.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Home.Controllers.Chat
{
    public class ChatController : BaseController
    {
        private readonly IChatApp _chatApp;

        public ChatController(IChatApp chatApp)
        {
            _chatApp = chatApp;
        }

        public ActionResult Index()
        {
            try
            {
                // Fazendo requisição para buscar conversas do usuário
                var response = _chatApp.GetConversas(UsuarioLogado.Id);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                // Instanciando Chat e deserializando resposta
                var conversas = JsonConvert.DeserializeObject<IEnumerable<Mensagem>>(response.Content.ReadAsStringAsync().Result);
                var chat = new ChatDto(UsuarioLogado, conversas);

                return View(chat);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult BuscarMensagens(int idUsuarioEnvio, int idUsuarioDestino, int pagina)
        {
            try
            {
                // Fazendo requisição para buscar mensagens do usuário
                var response = _chatApp.Get(idUsuarioEnvio, idUsuarioDestino, pagina);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                // Instanciando Mensagens e deserializando resposta
                var chat = new ChatDto
                {
                    Conversas = (IEnumerable<Mensagem>) JsonConvert.DeserializeObject<IEnumerable<Mensagem>>(response.Content.ReadAsStringAsync().Result)
                        .OrderBy(x => x.DataEnvio) ?? new List<Mensagem>()
                };

                return Json(chat, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }
    }
}