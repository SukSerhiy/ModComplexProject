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
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();
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
            IEnumerable<string> keys = new Select("Experiment").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            Experiment[] sprav_Acva_Arr = js.Deserialize<Experiment[]>(updateStringJson);

            foreach (Experiment s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_ex)))
            {
                Update.UpdateExperiment(s);
            }
            foreach (Experiment s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_ex)))
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
            Select s = new Select("Experiment");
            IEnumerable<string> headers = s.getHeaders();
            IEnumerable<IEnumerable<string>> data = s.getData();
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
            IEnumerable<string> keys = new Select("Scene").getData().Select(s => s.First());
            var js = new JavaScriptSerializer();
            Scene[] sprav_Acva_Arr = js.Deserialize<Scene[]>(updateStringJson);

            foreach (Scene s in sprav_Acva_Arr.Where(s => keys.Contains("" + s.Id_sc)))
            {
                Update.UpdateScene(s);
            }
            foreach (Scene s in sprav_Acva_Arr.Where(s => !keys.Contains("" + s.Id_sc)))
            {
                Insert.InsertScene(s);
            }
        }
    }
}