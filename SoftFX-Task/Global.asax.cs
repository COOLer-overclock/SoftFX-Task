using AutoMapper;
using SoftFX_Task.App_Start;
using SoftFX_Task.AutoMapper;
using SoftFX_Task.EntityFramework;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SoftFX_Task
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Timer timer = new Timer();
            timer.Interval = 5000;
            timer.Elapsed += AddData;
            //timer.Start();
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void AddData(object sender, System.Timers.ElapsedEventArgs e)
        {
            DataBaseContext _db = new DataBaseContext();
            CustomDatas.AddQuotesData(_db);
            _db.SaveChanges();
        }
    }
}
