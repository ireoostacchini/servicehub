using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using ServiceHub.Application;
using ServiceHub.DataService.Application.Helpers;

namespace ServiceHub.Test.Unit.Application
{
    [TestFixture]
    public class TestRowVersionHelper
    {
        [Test]
        public void Can_convert_between_string_and_byte_array()
        {
 
            
            var bytes = new byte[] { 255, 24 };

            var str = RowVersionHelper.ConvertToString(bytes);
                       
            var resultBytes = RowVersionHelper.ConvertToBytes(str);

            var resultStr = RowVersionHelper.ConvertToString(resultBytes);

            Assert.AreEqual(bytes, resultBytes);
            Assert.AreEqual(str, resultStr);

        }


    }
}
