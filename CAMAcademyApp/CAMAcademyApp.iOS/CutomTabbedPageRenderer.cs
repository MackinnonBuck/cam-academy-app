using CAMAcademyApp.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CutomTabbedPageRenderer))]
namespace CAMAcademyApp.iOS
{
    public class CutomTabbedPageRenderer : TabbedRenderer
    {
        /// <summary>
        /// Sets the bar tint color and the selected image tint color.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            TabBar.BarTintColor = new UIColor(35.0f / 255.0f, 44.0f / 255.0f, 101.0f / 255.0f, 1.0f);
            TabBar.SelectedImageTintColor = UIColor.White;
        }

        /// <summary>
        /// Adds an icon to the UIViewController and determines if ellipses should be displayed.
        /// </summary>
        /// <param name="childController"></param>
        public override void AddChildViewController(UIViewController childController)
        {
            base.AddChildViewController(childController);

            if (childController.Title.Equals("Links and Documents"))
                childController.TabBarItem.Image = UIImage.FromBundle("Link");
            else
                childController.TabBarItem.Image = UIImage.FromBundle("WebAsset");

            UIStringAttributes attributes = new UIStringAttributes
            {
                Font = UITabBarItem.Appearance.GetTitleTextAttributes(UIControlState.Normal).Font
            };
            
            if (MoreNavigationController.TabBarController == null)
            {
                foreach (UIViewController controller in ViewControllers)
                {
                    NSString nsString = new NSString(controller.Title);
                    CoreGraphics.CGSize size = nsString.GetSizeUsingAttributes(attributes);

                    while (size.Width > UIScreen.MainScreen.Bounds.Width / ViewControllers.Count())
                    {
                        controller.Title = controller.Title.Substring(0, controller.Title.Length - 4) + "...";

                        nsString = new NSString(controller.Title);
                        size = nsString.GetSizeUsingAttributes(attributes);
                    }
                }
            }
        }
    }
}