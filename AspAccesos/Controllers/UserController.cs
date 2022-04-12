using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspAccesos.Models;

namespace AspAccesos.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            try
            {
                using (AccesosContext db = new AccesosContext())
                {
                    var lst = (from d in db.TUsuarios
                               where d.Usuario == usuario & d.Password == password & d.IdEstado == 1
                               select d);
                    if (lst.Count() > 0)
                    {
                        Session["user"] = lst.FirstOrDefault();
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario y/o Contraseña incorrectas");
                    }
                }           
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}