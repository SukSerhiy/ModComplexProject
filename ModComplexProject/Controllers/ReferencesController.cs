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
    public class ReferencesController : Controller
    {
        //Справочник->акваторий
        public ActionResult WaterReference()
        {
            Select s = new Select("Sprav_acva");
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("WaterReference");
        }

        [HttpPost]
        public void WaterReference(string updateStringJson)
        {
            IEnumerable<string> keys = new Select("Sprav_acva").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            Sprav_Acva[] sprav_Acva_Arr = js.Deserialize<Sprav_Acva[]>(updateStringJson);

            foreach(Sprav_Acva s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_acv)))
            {
                Update.UpdateSprav_Acva(s);
            }
            foreach(Sprav_Acva s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_acv)))
            {
                Insert.InsertSprav_Acva(s);
            }
        }

        //Справочник->ГАС
        [HttpGet]
        public ActionResult GASReference()
        {
            Select s = new Select("Sprav_GAS");
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("GASReference");
        }
        
        public void GASReference(string updateStringJson)
        {
            IEnumerable<string> keys = new Select("Sprav_GAS").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            Sprav_GAS[] sprav_Acva_Arr = js.Deserialize<Sprav_GAS[]>(updateStringJson);

            foreach (Sprav_GAS s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_GAS)))
            {
                Update.UpdateSprav_Acva(s);
            }
            foreach (Sprav_GAS s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_GAS)))
            {
                Insert.InsertSprav_GAS(s);
            }
        }

        //Справочник->объектов
        public ActionResult ObjectsReference()
        {
            Select s = new Select("Sprav_Objects");
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("ObjectsReference");
        }

        [HttpPost]
        public void ObjectsReference(string updateStringJson)
        {
            IEnumerable<string> keys = new Select("Sprav_Objects").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            Sprav_Objects[] sprav_Acva_Arr = js.Deserialize<Sprav_Objects[]>(updateStringJson);

            foreach (Sprav_Objects s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_GAS)))
            {
                Update.UpdateSprav_Objects(s);
            }
            foreach (Sprav_Objects s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_GAS)))
            {
                Insert.InsertSprav_Objects(s);
            }
        }
    }
}