using Autofac;
using CompitetativeProject.DataRepository.Models;
using CompitetativeProject.DataRepository.Repository;
using CompitetativeProject.Util.GlobalUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace CompitetativeProject.Core.Lib
{
   public class CityLib
    {
          #region "Private Variables"
        private IComponentContext _componentContext;
        #endregion

        #region "Constructor & Destructor"
        /// <summary>
        /// Public Constructor.
        /// </summary>
        /// <param name="componentContext"></param>
        public CityLib(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }
        #endregion

        public List<City> GetAllCityList()
        {
            try
            {
                List<City> cities = new List<City>();
                using (var cityContext = _componentContext.Resolve<IDataRepository<City>>()) {
                    cities = cityContext.GetAll().ToList();
                
                }
                return cities;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }


        public List<Post> GetAllPostList()
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (var postContext = _componentContext.Resolve<IDataRepository<Post>>())
                {
                    posts = postContext.GetAll().ToList();
                    foreach (var post in posts)
                    {
                        post.ImagePath = HostingEnvironment.MapPath(post.ImagePath);
                    }
                }
                return posts;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }


        public List<Post> GetAllPostListByCity(int cityId)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (var postContext = _componentContext.Resolve<IDataRepository<Post>>())
                {
                    posts = postContext.Fetch(x=>x.CityId==cityId).ToList();
                    foreach (var post in posts)
                    {
                        post.ImagePath = HostingEnvironment.MapPath(post.ImagePath);
                    }
                }
                return posts;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }

        public List<Post> GetAllPostListByArea(int areaId)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (var postContext = _componentContext.Resolve<IDataRepository<Post>>())
                {
                    posts = postContext.Fetch(x => x.AreaId == areaId).ToList();

                }
                return posts;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }
        public List<Post> GetAllPostListByDateRange(DateTime startDate,DateTime endDate)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (var postContext = _componentContext.Resolve<IDataRepository<Post>>())
                {
                    posts = postContext.Fetch(x => x.OccurredDateTime>= startDate && x.OccurredDateTime<=endDate).ToList();
                    foreach (var post in posts)
                    {
                        post.ImagePath = HostingEnvironment.MapPath(post.ImagePath);
                    }
                }
                return posts;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }


        public List<Post> GetAllPostListByCityAreaDateRange(int cityId, int areaId, DateTime startDate, DateTime endDate)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (var postContext = _componentContext.Resolve<IDataRepository<Post>>())
                {
                   IQueryable<Post> postList = postContext.GetAll();
                    if (cityId != 0)
                        postList = postList.Where(x => x.CityId==cityId);
                    if (areaId != 0)
                        postList = postList.Where(x => x.AreaId == areaId);
                    if (startDate != null && endDate != null)
                        postList = postList.Where(x => x.OccurredDateTime >= startDate && x.OccurredDateTime <= endDate);
                    posts = postList.ToList();
                    foreach (var post in posts)
                    {
                        post.ImagePath = HostingEnvironment.MapPath(post.ImagePath);
                    }
                }
                return posts;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }
      
        public List<Area> GetAllAreaListByCityId(int cityId)
        {
            try
            {
                List<Area> areas = new List<Area>();
                using (var areaContext = _componentContext.Resolve<IDataRepository<Area>>())
                {
                    areas = areaContext.Fetch(x=>x.CityId==cityId).ToList();
                }
                return areas;
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            return null;
        }
       
       public Post SavePost(Post post){
           try{
               using (var postContext = _componentContext.Resolve<IDataRepository<Post>>())
               {
               if (post.Id != 0)
                  postContext.Update(post);
               else
                   postContext.Add(post);
               postContext.SaveChanges();
               }
           }
           catch (Exception ex)
           {
               GlobalUtil.HandleAndLogException(ex, this);
           }
           return post;
       }




       
        #region "Dispose Method(s)"
        /// <summary>
        /// Method call when 
        /// </summary>
        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {
                GlobalUtil.HandleAndLogException(ex, this);
            }
            finally
            {

            }
        }

        #endregion
    }
}
