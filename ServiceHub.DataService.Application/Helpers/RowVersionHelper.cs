using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceHub.DataService.Application.Helpers
{
    /// <summary>
    /// This allows us to convert Entity Framework RowVersion column (a fixed-length 8-byte array)
    /// to a string, pass it to the web client and back, convert it back to bytes,
    /// and check against the DB value for changes.
    /// It does the job - but eTags and Guids are more RESTful.
    /// </summary>
    public static class RowVersionHelper
    {
        public static byte[] ConvertToBytes(string version)
        {
            return Convert.FromBase64String(version);



        }

        public static string ConvertToString(byte[] bytes)
        {
           return Convert.ToBase64String(bytes);


    
        }



    }
}
