using Autofac;
using CompitetativeProject.Core.Lib;
using CompitetativeProject.DataRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CompitetativeProject.Core.Controllers
{
    public class HomeController : Controller
    {
        #region "Private variables"
        private readonly IComponentContext _componentContext;
        #endregion

        public HomeController(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public JsonResult GetAllCities()
        {
            var cityList = new List<City>();
            var cityContext = _componentContext.Resolve<CityLib>();
            cityList = cityContext.GetAllCityList();
            return Json(cityList);
        }
        [HttpPost]
        public JsonResult GetAllAreaByCityId(int cityId)
        {
            var areaList = new List<Area>();
            var areaContext = _componentContext.Resolve<CityLib>();
            areaList = areaContext.GetAllAreaListByCityId(cityId);
            return Json(areaList);
        }


        [HttpPost]
        public JsonResult GetAllPost()
        {
            var postList = new List<Post>();
            var postContext = _componentContext.Resolve<CityLib>();
            postList = postContext.GetAllPostList();
            return Json(postList);
        }

        [HttpPost]
        public JsonResult SavePost(Post post)
        {
            if (ModelState.IsValid)
            {
                var postContext = _componentContext.Resolve<CityLib>();
                 post= postContext.SavePost(post);
                return Json(post);
            }
            return Json(null);
        }

        [HttpPost]
        public JsonResult GetAllPostForTimeLine(int cityId, int areaId, DateTime startDate, DateTime endDate)
        {
            var postList = new List<Post>();
            var postContext = _componentContext.Resolve<CityLib>();
            postList = postContext.GetAllPostListByCityAreaDateRange(cityId,areaId,startDate,endDate);
            return Json(postList);
        }

    }
}
