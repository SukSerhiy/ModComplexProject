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
    /// Menu item "Эксперимент"
    /// </summary>
    /// <returns></returns>
    public class ExperimentController : Controller
    {
        /// <summary>
        /// Menu item "Регистрация эксперимента"
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterExperiment()
        {
            Select s = new Select("Experiment");
            var headers = s.getHeaders();
            var data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("RegisterExperiment");
        }

        /// <summary>
        /// Menu item "Регистрация эксперимента". Updating the DB table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void RegisterExperiment(string updateStringJson)
        {
            var keys = new Select("Experiment").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            var sprav_Acva_Arr = js.Deserialize<Experiment[]>(updateStringJson);

            foreach (var s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_ex)))
            {
                Update.UpdateExperiment(s);
            }
            foreach (var s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_ex)))
            {
                Insert.InsertExperiment(s);
            }
        }

        /// <summary>
        /// Menu item "Регистрация сцены"
        /// </summary>
        /// <returns></returns>
        public ActionResult RegisterScene()
        {
            var s = new Select("Experiment");
            var headers = s.getHeaders();
            var data = s.getData();
            ViewData["Table"] = new Table { headers = headers, data = data };
            return View("RegisterExperiment");
        }

        /// <summary>
        /// Menu item "Регистрация сцены". Updating the DB table
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public void RegisterScene(string updateStringJson)
        {
            var keys = new Select("Scene").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            var sprav_Acva_Arr = js.Deserialize<Scene[]>(updateStringJson);

            foreach (var s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_sc)))
            {
                Update.UpdateScene(s);
            }
            foreach (var s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_sc)))
            {
                Insert.InsertScene(s);
            }
        }
    }
}