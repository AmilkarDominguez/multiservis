﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using multiservis.Models;

namespace multiservis.Controllers
{
    public class RolController : Controller
    {
        // GET: Rol
        multiservisEntities BD = new multiservisEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Guardar(int id, string nombre, bool estado)
        {
            rol obj;
            string error = "";
            if (string.IsNullOrEmpty(nombre))
                error = "El campo nombre esta vacio";

            if (BD.rol.ToList().Exists(o => o.nombre == nombre) && id == 0)
                error = "Ya existe un objeto con es nombre";

            if (string.IsNullOrEmpty(error))
            {
                if (id == 0)
                {
                    obj = new rol();
                    obj.nombre = nombre;
                    obj.estado = estado;
                    BD.rol.Add(obj);
                    BD.SaveChanges();
                }
                else
                {
                    obj = BD.rol.Single(o => o.id == id);
                    obj.nombre = nombre;
                    obj.estado = estado;
                    BD.SaveChanges();
                }
            }

            return Json(error, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Listar()
        {
            string cadena = "";
            cadena = "<table id='data' class='display highlight' cellspacing='0' hidden>";
            cadena += "<thead class='red darken-3 white-text z-depth-3'>";
            cadena += "<tr>";
            cadena += "<th>Nombre</th>";
            cadena += "<th>Estado</th>";
            cadena += "<th>Opciones</th>";
            cadena += "</tr>";
            cadena += "</thead>";
            cadena += "<tbody>";
            foreach (var obj in BD.rol.ToList())
            {
                cadena += "<tr>";
                cadena += "<td>" + obj.nombre + "</td>";
                if (obj.estado)
                {
                    cadena += "<td>Activo</td>";
                }
                else
                {
                    cadena += "<td>Inactivo</td>";
                }
                cadena += "<td>";
                cadena += "<a class='waves-effect waves-light btn btn-floating blue'><i class='icon-pencil-1' onclick='Editar(" + obj.id + ");'></i></a>&nbsp;";
                cadena += "<a class='waves-effect waves-light btn btn-floating red'><i class='icon-trash' onclick='ModalConfirmar(" + obj.id + ",\"" + obj.nombre + "\");'></i></a>";
                cadena += "</td>";
                cadena += "</tr>";
            }
            cadena += "</tbody>";
            cadena += "</table>";
            return Json(cadena, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Get(int id)
        {
            rol obj = BD.rol.Single(o => o.id == id);
            var tiposervicio = new
            {
                nombre = obj.nombre,
                estado = obj.estado
            };
            return Json(tiposervicio, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            try
            {
                         rol obj = BD.rol.Single(o => o.id == id);
            BD.rol.Remove(obj);
            BD.SaveChanges();
            return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ListarSelectRoles()
        {
            string cadena = "<select id='selectRol'>";
            cadena += "<option value='' disabled selected>(Seleccionar)</option>";
            foreach (var item in BD.rol.ToList().Where(o => o.estado))
            {
                cadena += "<option value=" + item.id + ">" + item.nombre + "</option>";
            }
            cadena += "</select>";
            return Json(cadena, JsonRequestBehavior.AllowGet);
        }

    }
}