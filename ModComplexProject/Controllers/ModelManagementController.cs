using ModComplexProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WorkWithDb;

namespace ModComplexProject.Controllers
{
    /// <summary>
    /// Menu item "Управление моделями"
    /// </summary>
    /// <returns></returns>
    public class ModelManagementController : Controller
    {
        public ActionResult Index()
        {
            Select s = new Select("Model");
            var headers = s.getHeaders();
            var data = s.getData();
            return View("Index", new Table { headers = headers, data = data });
        }

        [HttpPost]
        public void Index(string updateStringJson)
        {
            var js = new JavaScriptSerializer();
            var model_Arr = js.Deserialize<Model[]>(updateStringJson);
            foreach (var m in model_Arr)
            {
                Update.UpdateModel(m);
            }
        }
    }
}