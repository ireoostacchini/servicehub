using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceHub.Infrastructure.Interfaces;
using log4net;
using log4net.Config;
using System.IO;
using System.Xml.Linq;

using ServiceHub.Infrastructure.Helpers;


namespace ServiceHub.Infrastructure
{
    public class Logger : ILogger
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Logger));

        static Logger()
        {
            var appDirectoryPath = DirectoryHelper.GetApplicationDirectory();

            var binDirectoryPath = DirectoryHelper.GetBinDirectory();


            var configFilePath = Path.Combine(binDirectoryPath, "Log4net.config");


            XDocument doc = XDocument.Load(configFilePath);

            //do any customisation here
            ModifyConfiguration(doc);

            XmlConfigurator.Configure(doc.Root.ToXmlElement());


        }

        /// <summary>
        /// Modify the config loaded from the XML file, before it's applied
        /// </summary>
        /// <param name="doc"></param>
        private static void ModifyConfiguration(XDocument doc)
        {
            var rollingFileAppender = doc.Descendants("appender")
                .First(x => x.Attribute("name").Value == "rollingFileAppender");




            //if it's a windows app, the log files are put in the bin directory by default
            //- here we move them up to the project directory
            if (DirectoryHelper.IsWindowsApplication)
            {
                var fileParam = rollingFileAppender
                    .Descendants("param")
                    .First(x => x.Attribute("name").Value == "File");

                fileParam.Attribute("value").Value = @"..\..\" + fileParam.Attribute("value").Value;
            }
        }



        public void Debug(object message)
        {
            logger.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            logger.Debug(message, exception);
        }

        public void Error(object message)
        {
            logger.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            logger.Error(message, exception);
        }

        public void Fatal(object message)
        {
            logger.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            logger.Fatal(message, exception);
        }

        public void Info(object message)
        {
            logger.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            logger.Info(message, exception);
        }

        public void Warn(object message)
        {
            logger.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            logger.Warn(message, exception);
        }

        public bool isDebugEnabled
        {
            get { return logger.IsDebugEnabled; }
        }

        public bool isErrorEnabled
        {
            get { return logger.IsErrorEnabled; }
        }

        public bool isFatalEnabled
        {
            get { return logger.IsFatalEnabled; }
        }

        public bool isInfoEnabled
        {
            get { return logger.IsInfoEnabled; }
        }

        public bool isWarnEnabled
        {
            get { return logger.IsWarnEnabled; }
        }
    }
}
