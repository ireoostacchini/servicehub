using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.UI.Interfaces
{
    public interface IConfig
    {
        string DataServiceBaseUrl { get; }
        int MonitorInterval { get; }
    }
}
