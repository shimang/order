using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QCloud.WeApp.SDK;

namespace QCloud.WeApp.Demo.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //使用代码初始化：
            var configuration = new Configuration()
            {
                // 业务服务器访问域名
                ServerHost = "127.0.0.1",//"199447.qcloud.la",
                // 鉴权服务地址
                AuthServerUrl = "http://10.0.12.135/mina_auth/",
                // 信道服务地址
                TunnelServerUrl = "https://ws.qcloud.com/",
                // 信道服务签名 key
                TunnelSignatureKey = "my$ecretkey",
                // 网络请求超时设置，单位为豪秒
                //NetworkTimeout = 30000
            };
            ConfigurationManager.Setup(configuration);


            //使用配置文件初始化：
            //var configFilePath = "C:\\qcloud\sdk.config";
            //ConfigurationManager.SetupFromFile(configFilePath);

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            QCloudConfig.Setup();


        }
    }
}
