using CineGT.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CineGT.Controllers
{
    public class AccesoController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario oUsuario)
        {
            string user = oUsuario.User;
            string clave = oUsuario.Clave;
            string connectionString = $"Server=DIEGO\\SQLEXPRESS;Database=CineGT;User Id={user};Password={clave};";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();
                    HttpContext.Session.SetString("Usuario", user);
                    return RedirectToAction("Index", "Home");
                }
            }catch (SqlException)
            {
                ViewData["Mensaje"] = "Usuario o contraseña incorrectos.";
                return View();
            }

        }

    }
}
