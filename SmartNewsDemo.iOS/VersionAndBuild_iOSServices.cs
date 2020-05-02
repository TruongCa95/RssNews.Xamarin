using Foundation;
using SmartNewsDemo.Common.Services.Interface;
using SmartNewsDemo.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(VersionAndBuild_iOSServices))]
namespace SmartNewsDemo.iOS
{
    public class VersionAndBuild_iOSServices : IAppVersionAndBuild
    {
        public string GetBuildNumber()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }

        public string GetVersionNumber()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
    }
}