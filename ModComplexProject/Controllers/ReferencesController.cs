using ModComplexProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WorkWithDb;

namespace ModComplexProject.Controllers
{
    /// <summary>
    /// Menu item "Справочник"
    /// </summary>
    /// <returns></returns>
    public class ReferencesController : Controller
    {
        /// <summary>
        /// Menu item "Акваторий"
        /// </summary>
        /// <returns></returns>
        public ActionResult WaterReference()
        {
            Select s = new Select("Sprav_acva");
            var headers = s.getHeaders();
            var data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("WaterReference");
        }

        /// <summary>
        /// Menu item "Акваторий". Updating the DB table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void WaterReference(string updateStringJson)
        {
            var keys = new Select("Sprav_acva").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            var sprav_Acva_Arr = js.Deserialize<Sprav_Acva[]>(updateStringJson);

            foreach(var s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_acv)))
            {
                Update.UpdateSprav_Acva(s);
            }
            foreach(var s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_acv)))
            {
                Insert.InsertSprav_Acva(s);
            }
        }

        /// <summary>
        /// Menu item "ГАС"
        /// </summary>
        /// <returns></returns>
        public ActionResult GASReference()
        {
            Select s = new Select("Sprav_GAS");
            var headers = s.getHeaders();
            var data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("GASReference");
        }

        /// <summary>
        /// Menu item "ГАС". Updating the DB table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void GASReference(string updateStringJson)
        {
            var keys = new Select("Sprav_GAS").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            var sprav_Acva_Arr = js.Deserialize<Sprav_GAS[]>(updateStringJson);

            foreach (var s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_GAS)))
            {
                Update.UpdateSprav_GAS(s);
            }
            foreach (var s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_GAS)))
            {
                Insert.InsertSprav_GAS(s);
            }
        }

        /// <summary>
        /// Menu item "Объектов"
        /// </summary>
        /// <returns></returns>
        public ActionResult ObjectsReference()
        {
            Select s = new Select("Sprav_Objects");
            var headers = s.getHeaders();
            var data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("ObjectsReference");
        }

        /// <summary>
        /// Menu item "Объектов". Updating the DB table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void ObjectsReference(string updateStringJson)
        {
            var keys = new Select("Sprav_Objects").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            Sprav_Objects[] sprav_Acva_Arr = js.Deserialize<Sprav_Objects[]>(updateStringJson);

            foreach (Sprav_Objects s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_obj)))
            {
                Update.UpdateSprav_Objects(s);
            }
            foreach (Sprav_Objects s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_obj)))
            {
                Insert.InsertSprav_Objects(s);
            }
        }
    }
}