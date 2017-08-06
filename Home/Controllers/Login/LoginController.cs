using Home.Application.Login;
using Home.Infra;
using Home.Infra.Security;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Serialization;

namespace Home.Controllers.Login
{
    public class LoginController : BaseController
    {
        private readonly ILoginApp _loginApp;

        public LoginController(ILoginApp loginApp)
        {   
            _loginApp = loginApp;
        }

        public ActionResult Index()
        {
            try
            {
                // Verificando se existe cookie e caso existir logar automaticamente
                if (Request.Cookies["fimpleUser"] != null)
                {
                    var userCookie = JsonConvert.DeserializeObject<Models.Entity.Usuario>(Security.Decrypt(Request.Cookies["fimpleUser"].Value));
                    userCookie.Senha = Security.Decrypt(userCookie.Senha);
                    return RedirectToAction("Entrar", "Login", userCookie);
                }

                // Verificando se usuário possui sessão ativa
                if (UsuarioLogado == null)
                    return View("Index");

                return RedirectToAction("Index", "TimeLine");
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult GetDados()
        {
            return View("_Dados");
        }

        public ActionResult Entrar(Models.Entity.Usuario usuario)
        {
            try
            {
                // Criptografando senha
                usuario.Senha = Security.Encrypt(usuario.Senha);

                // Requisição para validar login
                var response = _loginApp.Post(usuario);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                // Instanciando resposta
                var model = JsonConvert.DeserializeObject<Models.Entity.Usuario>(response.Content.ReadAsStringAsync().Result);

                // Verificando se foi encontrado algum usuário com este login
                if (model.Id == default(int))
                    return ErrorMessage("Usuario Não encontrado");

                // Verificando se a opção de lembrar senha está habilitada
                if (usuario.Lembrar.HasValue)
                {
                    // Serializando dados do usuário
                    var jsonEncrypt = Security.Encrypt(JsonConvert.SerializeObject(usuario));

                    // Criando cookie para lembrar a senha do usuário
                    var userCookie = new HttpCookie("fimpleUser", jsonEncrypt);
                    userCookie.Expires.AddDays(365);
                    HttpContext.Response.Cookies.Add(userCookie);
                }
                else
                    RemoveCookie();

                // Gravando Sessão para este usuário
                UsuarioLogado = model;

                return RedirectToAction("Index", "TimeLine");
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult Sair()
        {
            try
            {
                // Removendo Sessão do usuário logado
                UsuarioLogado = null;

                // Removendo cooke caso existir
                RemoveCookie();

                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        private void RemoveCookie()
        {
            if (Request.Cookies["fimpleUser"] == null) return;
            var userCookie = new HttpCookie("fimpleUser")
            {
                Expires = DateTime.Now.AddDays(-1),
                Value = null
            };
            Response.Cookies.Add(userCookie);
        }
    }
}