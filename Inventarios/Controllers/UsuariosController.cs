using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Management;
using System.Text;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.DirectoryServices;

namespace Inventarios.Controllers
{
    public class UsuariosController : Controller
    {
        //
        // GET: /Usuarios/
        public ActionResult Index()
        {
            List<List<String>> usuariosW = new List<List<String>>();

            ArrayList listaUsuariosAdmin = getListaUsuarios("Administrador");

            if (listaUsuariosAdmin != null)
            {
                foreach(String usuarioAdmin in listaUsuariosAdmin)
                {
                    List<String> usuario = new List<String>();
                    usuario.Add(usuarioAdmin);
                    usuario.Add("Administrador");
                    usuariosW.Add(usuario);
                }
            }

            ArrayList listaUsuariosMiembros = getListaUsuarios("Miembro");

            if (listaUsuariosMiembros != null)
            {
                foreach (String usuarioAdmin in listaUsuariosMiembros)
                {
                    List<String> usuario = new List<String>();
                    usuario.Add(usuarioAdmin);
                    usuario.Add("Miembro");
                    usuariosW.Add(usuario);
                }
            }

            ViewBag.Usuario = usuariosW;

            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }


        [HttpPost]
        public ActionResult Create(String nombreUsuario, String tipoUsuario,String password, String passwordR)
        {
            if (password.Equals(passwordR))
            {
                if (crearUsuario(nombreUsuario, tipoUsuario, password))
                {
                    return RedirectToAction("Index");
                }
                ViewBag.Error = "Error al crear el usuario. Es posible que ya exista o no tiene los permisos suficientes para crearlo.";
                return View();
            }
            ViewBag.Error = "Las contraseñas deben de coincidir.";
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(String usuarioAEliminar)
        {
            borrarCuenta(usuarioAEliminar);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteLink(String usuario)
        {
            ViewBag.Usuario = usuario;
            return View("Delete");
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult EditLink(String usuario, String tipoUsuario)
        {
            ViewBag.Usuario = usuario;
            ViewBag.TipoUsuario = tipoUsuario;
            return View("Edit");
        }

        [HttpPost]
        public ActionResult EditarPost(String nombreUsuario, String tipoUsuarioA, String tipoUsuarioN)
        {
            EditarUsuario(nombreUsuario, tipoUsuarioA, tipoUsuarioN);
            return RedirectToAction("Index");
        }


        private void EditarUsuario(String nombreUsuario, String tipoUsuarioA, String tipoUsuarioN)
        {
            RemoveUserFromGroup(nombreUsuario, tipoUsuarioA);
            string usuario = nombreUsuario;
            string grupo = tipoUsuarioN;
            string pc = "miEquipo";
            string PathNT = "WinNT://" + pc + ",computer";
            string PathUsuario = "WinNT://" + pc + "/" + usuario + ",user";
            string PathGrupo = "WinNT://" + pc + "/" + grupo + ",group";

                DirectoryEntry grupoNT = new DirectoryEntry(PathGrupo);
                grupoNT.Invoke("Add", new object[] { PathUsuario });
                grupoNT.CommitChanges();
        }


        public void RemoveUserFromGroup(string userId, string groupName)
        {
            string usuario = userId;
            string grupo = groupName;
            string pc = "miEquipo";
            string PathNT = "WinNT://" + pc + ",computer";
            string PathUsuario = "WinNT://" + pc + "/" + usuario + ",user";
            string PathGrupo = "WinNT://" + pc + "/" + grupo + ",group";

            DirectoryEntry grupoNT = new DirectoryEntry(PathGrupo);
            grupoNT.Invoke("remove", new object[] { PathUsuario });
            grupoNT.CommitChanges();
        }

        ArrayList getListaUsuarios(String grupo)
        {

            ArrayList listaUsuarios = new ArrayList();

            DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName);
            DirectoryEntry admGroup = localMachine.Children.Find(grupo, "group");
            object members = admGroup.Invoke("members", null);
            foreach (object groupMember in (IEnumerable)members)
            {
                DirectoryEntry member = new DirectoryEntry(groupMember);
                listaUsuarios.Add(member.Name);
            }

            return listaUsuarios;

        }

       
        private Boolean crearUsuario(String nombre, String tipo,String pass){
            string usuario = nombre;
            string grupo = tipo;
            string password = pass;
            string pc = "miEquipo";
            string PathNT = "WinNT://" + pc + ",computer";
            string PathUsuario = "WinNT://" + pc + "/" + usuario + ",user";
            string PathGrupo = "WinNT://" + pc + "/" + grupo + ",group";
        
            try
            {                
                DirectoryEntry NT = new DirectoryEntry(PathNT);
                DirectoryEntry NuevoUsuario = NT.Children.Add(usuario, "user");
                NuevoUsuario.Invoke("SetPassword", new object[] { password });
                NuevoUsuario.Invoke("Put", new object[] { "Description", "usuario auxiliar" });
                NuevoUsuario.Invoke("Put", new object[] {"UserFlags", 0x00010000}); //NeverExpires
                NuevoUsuario.CommitChanges();
             }
             catch (Exception ex)
             {
                 Console.Write(ex);
                 return false;
             }

             try // agregar a grupo
             {
                DirectoryEntry grupoNT = new DirectoryEntry(PathGrupo);
                grupoNT.Invoke("Add", new object[] { PathUsuario });
                grupoNT.CommitChanges();
             }
             catch (Exception g)
             {
                 return false;
             }
             return true;
        }

        private void borrarCuenta(String usuario)
        {
            DirectoryEntry localDirectory = new DirectoryEntry("WinNT://" + Environment.MachineName.ToString());
            DirectoryEntries users = localDirectory.Children;
            DirectoryEntry user = users.Find(usuario);
            users.Remove(user);
        }


        public ActionResult SignInAsDifferentUser()
        {

            HttpCookie cookie = base.Request.Cookies["TSWA-Last-User"];

            if (base.User.Identity.IsAuthenticated == false || cookie == null || StringComparer.OrdinalIgnoreCase.Equals(base.User.Identity.Name, cookie.Value))
            {

                string name = string.Empty;
                if (base.Request.IsAuthenticated)
                {
                    name = this.User.Identity.Name;
                }

                cookie = new HttpCookie("TSWA-Last-User", name);
                base.Response.Cookies.Set(cookie);

                base.Response.AppendHeader("Connection", "close");
                base.Response.StatusCode = 0x191;
                base.Response.Clear();
                base.Response.Write("Acceso denegado.");
                base.Response.End();
                return RedirectToAction("Index");
            }

            cookie = new HttpCookie("TSWA-Last-User", string.Empty)
            {
                Expires = DateTime.Now.AddYears(-5)
            };
            base.Response.Cookies.Set(cookie);

            return RedirectToRoute("Default", new { controller = "Home", action = "Index" });
        }



	}
}