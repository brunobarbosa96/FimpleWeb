using Home.Infra;
using System.Web.Mvc;

namespace Home.Controllers.Mapa
{
    public class MapaController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.NomeUsuario = UsuarioLogado.Nome;
            return View(UsuarioLogado);
        }
    }
}