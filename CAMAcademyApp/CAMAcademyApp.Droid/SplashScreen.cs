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
using Android.Webkit;
using CAMAcademyApp.Core;
using Java.Lang;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CAMAcademyApp.Droid
{
    [Activity(Label = "CAM Academy", Icon = "@drawable/icon", MainLauncher = true, NoHistory = true, Theme = "@style/MainTheme.Splash",
        ConfigurationChanges = Android.Content.PM.ConfigChanges.ScreenSize | Android.Content.PM.ConfigChanges.Orientation,
        ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Intent intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}