using System;
using System.Collections.Generic;
using System.Text;

namespace SmartNewsDemo.Common.Services.Interface
{
   public interface IAppVersionAndBuild
    {
        string GetVersionNumber();
        string GetBuildNumber();
    }
}
