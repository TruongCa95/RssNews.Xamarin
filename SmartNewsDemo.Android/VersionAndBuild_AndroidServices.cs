using Android.Content.PM;
using SmartNewsDemo.Common.Services.Interface;
using SmartNewsDemo.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(VersionAndBuild_AndroidServices))]
namespace SmartNewsDemo.Droid
{
    public class VersionAndBuild_AndroidServices : IAppVersionAndBuild
    {
        PackageInfo _appInfo;
        public VersionAndBuild_AndroidServices()
        {
            var context = Android.App.Application.Context;
            _appInfo = context.PackageManager.GetPackageInfo(context.PackageName, 0);
        }
        public string GetVersionNumber()
        {
            return _appInfo.VersionName;
        }
        public string GetBuildNumber()
        {
            return _appInfo.VersionCode.ToString();
        }
    }
}