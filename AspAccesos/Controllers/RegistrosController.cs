using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspAccesos.Models.ModelView;
using AspAccesos.Models;

namespace AspAccesos.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        public ActionResult Index()
        {
            List<RegistersView> lista = new List<RegistersView>();
            try
            {
                using (AccesosContext db = new AccesosContext())
                {
                    lista = (from d in db.TUsuarios
                             where d.IdEstado == 1
                             select new RegistersView
                             {
                                 Id = d.Id,
                                 Usuario = d.Usuario,
                                 Password = d.Password,
                                 Entidad = d.Entidad,
                             }).ToList();
                }
            }
            catch (Exception)
            {
                lista= null;
                return View(lista);
            }
            return View(lista);
        }
    }
}