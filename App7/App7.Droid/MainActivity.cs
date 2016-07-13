using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App7.Droid
{
    [Activity(Label = "App7", Icon = "@drawable/icon", MainLauncher = false, Theme = "@style/MyCustomTheme",  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App()  );
         Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
        }
        public override void OnBackPressed()
        {
            if (App7.Instance.DoBack)
            {
                base.OnBackPressed();
            }
        }
    }
}

