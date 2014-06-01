using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ServiceHub.Infrastructure.Helpers
{


    internal static class XElementExtensions
    {

        internal static XmlElement ToXmlElement(this XElement el)
        {

            var doc = new XmlDocument();

            doc.Load(el.CreateReader());

            return doc.DocumentElement;

        }

    }
}