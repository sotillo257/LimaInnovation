using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LimaInnovation.Models;

namespace LimaInnovation.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["Productos"] = ObtenerProductos();
            ViewBag.Productos = Session["Productos"];
            return View();
        }

        public ActionResult Carrito()
        {
            ViewBag.Productos = Session["Carrito"];
            return View();
        }

        private IEnumerable<cProducto> ObtenerProductos() {
            List<cProducto> productos = new List<cProducto>();

            productos.Add(new cProducto()
            {
                Id = 1,
                Nombre= "Manzana",
                Descripcion = "Las mejores Manzanas de la ciudad",
                Cantidad = 15,
                Categoria = "Frutas",
                Imagen = "~/Content/135288534.jpg"
            });

            productos.Add(new cProducto()
            {
                Id = 2,
                Nombre = "Pera",
                Descripcion = "Las mejores peras de la ciudad",
                Cantidad = 5,
                Categoria = "Frutas",
                Imagen = "~/Content/135288534.jpg"
            });

            productos.Add(new cProducto()
            {
                Id = 3,
                Nombre = "Duraznos",
                Descripcion = "Los mejores Duraznos de la ciudad",
                Cantidad = 10,
                Categoria = "Frutas",
                Imagen = "~/Content/135288534.jpg"
            });

            productos.Add(new cProducto()
            {
                Id = 4,
                Nombre = "Uva",
                Descripcion = "Las mejores Uva de la ciudad",
                Cantidad = 10,
                Categoria = "Frutas",
                Imagen = "~/Content/135288534.jpg"
            });

            return productos;
        }

        [HttpPost]
        public ActionResult AgregarProducto(cProducto pProducto)
        {
            try
            {
                List<cProducto> productos = (List<cProducto>)Session["Productos"];

                if (Session["Carrito"] == null)
                {
                    var xProducto = productos.Where(x => x.Id == pProducto.Id).ToList().FirstOrDefault();
                    xProducto.Cantidad = pProducto.Cantidad;
                    List<cProducto> cProductos = new List<cProducto>();
                    cProductos.Add(xProducto);
                    Session["Carrito"] = cProductos;
                }
                else
                {
                    var xProducto = productos.Where(x => x.Id == pProducto.Id).ToList().FirstOrDefault();
                    xProducto.Cantidad = pProducto.Cantidad;
                    List<cProducto> cProductos =(List<cProducto>)Session["Carrito"];
                    if (cProductos.Where(x=> x.Id == pProducto.Id).Count() > 0)
                    {
                        cProductos.Where(x => x.Id == pProducto.Id).FirstOrDefault().Cantidad += pProducto.Cantidad;                       
                    }
                    else
                    {
                        cProductos.Add(xProducto);
                    }
                    
                    Session["Carrito"] = cProductos;
                }

                return Json(new { Result = true });
            }
            catch (Exception ex)
            {
                return Json(new { Result = false });
            }

            
        }
    }
}
