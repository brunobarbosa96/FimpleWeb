using Home.Application.Notificacao;
using Home.Infra;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Home.Controllers.Notificacao
{
    public class NotificacaoController : BaseController
    {
        private readonly INotificacaoApp _notificacaoApp;

        public NotificacaoController(INotificacaoApp notificacaoApp)
        {
            _notificacaoApp = notificacaoApp;
        }

        public ActionResult Index()
        {
            try
            {
                var response = _notificacaoApp.Get(UsuarioLogado.Id);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                var notificacoes = JsonConvert.DeserializeObject<IEnumerable<Models.Entity.Notificacao>>(
                    response.Content.ReadAsStringAsync().Result);

                return View("_Index", notificacoes);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult Put(Models.Entity.Notificacao notificacao)
        {
            try
            {
                var response = _notificacaoApp.Put(notificacao);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }
    }
}