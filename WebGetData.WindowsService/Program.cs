//#define Dev

using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WebGetData.WindowsService
{

    static class Program
    {
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

#if Dev
        private static void Main(string[] args)
        {
            try
            {

                test test = new test();
                test.OnStart();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }

#else
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            try
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                 { 
                new Service1() 
                  };
                ServiceBase.Run(ServicesToRun);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }
#endif
    }
}
