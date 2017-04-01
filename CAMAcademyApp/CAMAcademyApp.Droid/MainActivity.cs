using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CAMAcademyApp.Droid
{
    [Activity(Label = "CAM Academy", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            AndroidEnvironment.UnhandledExceptionRaiser += AndroidEnvironmentUnhandledExceptionRaiser;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        /// <summary>
        /// Handles a highly-specific Xamarin bug in which pressing the back button when the MainPage is a MasterDetailPage results in a crash.
        /// This method will just silently close the app in this case and restart if the user resumes it from the task switcher.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AndroidEnvironmentUnhandledExceptionRaiser(object sender, RaiseThrowableEventArgs e)
        {
            if (e.Exception.GetType() == typeof(Java.Lang.IllegalStateException))
                Process.KillProcess(Process.MyPid());
        }
    }
}

