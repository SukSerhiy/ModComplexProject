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
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();
            return View("Index", new Table { headers = headers, data = data });
        }

        [HttpPost]
        public void Index(string updateStringJson)
        {
            var js = new JavaScriptSerializer();
            Model[] model_Arr = js.Deserialize<Model[]>(updateStringJson);
            foreach (Model m in model_Arr)
            {
                Update.UpdateModel(m);
            }
        }
    }
}