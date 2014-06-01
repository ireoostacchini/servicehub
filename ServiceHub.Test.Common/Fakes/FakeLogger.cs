using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServiceHub.Infrastructure.Interfaces;


namespace ServiceHub.Test.Common.Fakes
{
    public class FakeLogger : ILogger
    {

        //a duplicate of the one in Tests.Unit - we should really extract to a Tests.Common project

        public void Debug(object message){}

        public void Debug(object message, Exception exception){}
        public void Error(object message){}
        public void Error(object message, Exception exception){}
        public void Fatal(object message){}
        public void Fatal(object message, Exception exception){}
        public void Info(object message){}
        public void Info(object message, Exception exception){}
        public void Warn(object message){}
        public void Warn(object message, Exception exception){}

        public bool isDebugEnabled
        {
            get { return true; }
        }

        public bool isErrorEnabled
        {
            get { return true; }
        }

        public bool isFatalEnabled
        {
            get { return true; }
        }

        public bool isInfoEnabled
        {
            get { return true; }
        }

        public bool isWarnEnabled
        {
            get { return true; }
        }
    }
}
