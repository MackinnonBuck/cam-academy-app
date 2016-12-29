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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using CAMAcademyApp;
using CAMAcademyApp.Droid;
using CAMAcademyApp.Core;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace CAMAcademyApp.Droid
{
    /// <summary>
    /// The Android renderer implementation of CustomWebView.
    /// </summary>
    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, Android.Webkit.WebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                Android.Webkit.WebView webView = new Android.Webkit.WebView(Forms.Context);

                SetNativeControl(webView);
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.DisplayZoomControls = false;
            }

            if (e.NewElement != null)
            {
                Control.LoadDataWithBaseURL("", Element.SourceHTML, "text/html", "UTF-8", "");
            }
        }
    }
}