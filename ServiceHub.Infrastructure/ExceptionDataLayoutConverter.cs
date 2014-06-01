using System;
using System.Collections;
using System.IO;

using log4net.Core;
using log4net.Layout.Pattern;

namespace ServiceHub.Infrastructure
{
    public class ExceptionDataLayoutConverter : PatternLayoutConverter
    {
        protected override void Convert(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (loggingEvent.ExceptionObject != null)
            {
                foreach (DictionaryEntry dictionaryEntry in loggingEvent.ExceptionObject.Data)
                {
                    writer.WriteLine("{0} {1}", dictionaryEntry.Key, dictionaryEntry.Value);
                }
            }
        }
    }
}