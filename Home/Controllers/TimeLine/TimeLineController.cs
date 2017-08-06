using Home.Application.Timeline;
using Home.Infra;
using Home.Models.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Home.Controllers.Timeline
{
    public class TimelineController : BaseController
    {
        private readonly IPublicacaoApp _publicacaoApp;
        private readonly IComentarioApp _comentarioApp;

        public TimelineController(IPublicacaoApp publicacaoApp, IComentarioApp comentarioApp)
        {
            _publicacaoApp = publicacaoApp;
            _comentarioApp = comentarioApp;
        }

        public ActionResult Index()
        {
            try
            {
                ViewBag.NomeUsuario = UsuarioLogado.Nome;
                return View(UsuarioLogado);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult GetAll(int pagina)
        {
            try
            {
                var response = _publicacaoApp.GetAll(UsuarioLogado.Id, pagina);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                var publicacoes = JsonConvert.DeserializeObject<IEnumerable<Publicacao>>(response.Content.ReadAsStringAsync().Result);
                ViewBag.UsuarioLogado = UsuarioLogado;
                return View("_Publicacao", publicacoes);
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult Post(Publicacao publicacao)
        {
            try
            {
                var response = _publicacaoApp.Post(publicacao);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult Put(Publicacao publicacao)
        {
            try
            {
                var response = _publicacaoApp.Put(publicacao);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var response = _publicacaoApp.Delete(id);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        [ValidateInput(false)]
        public ActionResult PostComentario(Comentario comentario)
        {
            try
            {
                var response = _comentarioApp.Post(comentario);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        [ValidateInput(false)]
        public ActionResult PutComentario(Comentario comentario)
        {
            try
            {
                var response = _comentarioApp.Put(comentario);
                if (!response.IsSuccessStatusCode)
                    return ErrorMessage(response.Content.ReadAsStringAsync().Result);

                return new EmptyResult();
            }
            catch (Exception ex)
            {
                return ErrorMessage(ex.Message);
            }
        }

        public ActionResult DeleteComentario(int id)
        {
            try
            {
                var response = _comentarioApp.Delete(id);
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