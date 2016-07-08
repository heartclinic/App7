using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using App7.DependencySvcDevice;
using App7.Droid.DependencySvcDevice;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidDevice))]
namespace App7.Droid.DependencySvcDevice
{
    class AndroidDevice : IDevice
    {
        public string GetIdentifier()
        {
            return Settings.Secure.GetString(Android.App.Application.Context.ContentResolver, Settings.Secure.AndroidId);
        }
    }
}