using CAMAcademyApp.Core;
using CAMAcademyApp.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]
namespace CAMAcademyApp.iOS
{
    public class CustomWebViewRenderer : ViewRenderer<CustomWebView, UIWebView>
    {
        /// <summary>
        /// Creates a UIWebView and sets that as the native control.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<CustomWebView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                UIWebView webView = new UIWebView(Frame);
                SetNativeControl(webView);
            }

            if (e.NewElement != null)
            {
                Control.LoadHtmlString(Element.SourceHTML, null);
            }
        }
    }
}
