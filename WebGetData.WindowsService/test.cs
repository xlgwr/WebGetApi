using log4net;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WebGetData.WindowsService
{
    public partial class test
    {
        public static ILog log;

        // First we must get a reference to a scheduler
        ISchedulerFactory sf;
        IScheduler sched;

        //public Service1()
        //{
        //    InitializeComponent();

        //}
        public void OnStart()
        {
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            try
            {
                log.Info("------- Initializing ----------------------");
                // First we must get a reference to a scheduler
                sf = new StdSchedulerFactory();
                sched = sf.GetScheduler();
                log.Info("------- Initialization Complete -----------");

            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            // Start up the scheduler (nothing can actually run until the 
            // scheduler has been started)
            sched.Start();
            log.Info("------- Started Scheduler -----------------");

        }

        public void OnStop()
        {
            // shut down the scheduler
            log.Info("------- Shutting Down ---------------------");
            sched.Shutdown(true);
            log.Info("------- Shutdown Complete -----------------");

        }
    }
}
