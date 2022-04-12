using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AspAccesos.Models.ModelView;
using AspAccesos.Models;
using AspAccesos.Models.ModelHtmlView;

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
        
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(AgregarRegistroView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using(AccesosContext db = new AccesosContext())
            {
                var oUser = new TUsuarios();
                oUser.Usuario = model.usuario;
                oUser.Password = model.contrasena;
                oUser.Entidad = model.entidad;
                oUser.IdEstado = 1;
                db.TUsuarios.Add(oUser);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Registros/Index"));
        }
        [HttpGet]
        public ActionResult Editar(int id)
        {
            EditarRegistroView modelo = new EditarRegistroView();
            using (AccesosContext db = new AccesosContext())
            {         
                var Ouser = db.TUsuarios.Find(id);
                modelo.id = Ouser.Id;
                modelo.usuario = Ouser.Usuario;
                modelo.entidad = Ouser.Entidad;
            }
            return View(modelo);
        }
        [HttpPost]
        public ActionResult Editar(EditarRegistroView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (AccesosContext db = new AccesosContext())
            {
                var Ouser = db.TUsuarios.Find(model.id);
                Ouser.Usuario = model.usuario;
                Ouser.Entidad = model.entidad;
                Ouser.Id = model.id;
                if (model.password != null && model.password.Trim() != "" )
                {
                    Ouser.Password = model.password;
                }
                db.Entry(Ouser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Registros/Index"));
        }
        [HttpGet]
        public ActionResult BorradoLogico(int Id)
        {
            using (AccesosContext db = new AccesosContext())
            {
                var oUser = db.TUsuarios.Find(Id);
                oUser.IdEstado = 2;
                db.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Registros/Index"));
        }
    }
}