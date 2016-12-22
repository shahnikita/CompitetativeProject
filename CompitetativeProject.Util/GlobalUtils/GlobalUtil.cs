using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CompitetativeProject.Util.GlobalUtils
{
    public static class GlobalUtil
    {
        #region "Public Method(s)"

        /// <summary>
        /// Method for Handling and logging Exceptions.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="callingType"> </param>
        public static void HandleAndLogException(Exception ex, object callingType)
        {
            var log = LogManager.GetLogger(callingType.GetType());
            if (!log.IsErrorEnabled) return;
            log.Error(ex.Message, ex);
            throw ex;
        }

        /// <summary>
        /// Method for Handling and logging Exceptions.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="callingType"> </param>
        public static void HandleAndLogException(Exception ex, Type callingType)
        {
            var log = LogManager.GetLogger(callingType);
            if (!log.IsErrorEnabled) return;
            log.Error(ex.Message, ex);
            throw new Exception(ex.Message, ex);
        }

        /// <summary>
        /// Method for logging info 
        ///  </summary>
        /// <param name="info"></param>
        /// <param name="callingType"> </param>
        public static void LogInfo(string info, Type callingType)
        {
            try
            {
                var log = LogManager.GetLogger(callingType);
                if (log.IsInfoEnabled)
                {
                    log.Info(info);
                }
            }
            catch (Exception ex)
            {
                HandleAndLogException(ex, typeof(GlobalUtil));
            }
        }

        #endregion
    }
}
