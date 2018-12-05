
using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;

namespace ClassLibraryExample.Droid
{
    [Activity(Theme = "@style/SplashTheme",Label = "SplashActivity", MainLauncher = true)]
    public class SplashActivity : MvxSplashScreenActivity<MvxAndroidSetup<Core.App>, Core.App>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}