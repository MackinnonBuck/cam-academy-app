using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class SplashScreen : ContentPage
    {
        public SplashScreen()
        {
            BackgroundColor = CAMColors.Primary;

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Image
                    {
                        Source = ImageSource.FromFile("alpha_icon.png")
                    },
                    new ActivityIndicator
                    {
                        Color = CAMColors.Accent,
                        IsRunning = true
                    },
                    new Label
                    {
                        Text = "Connecting to Database...",
                        TextColor = CAMColors.Accent,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        HorizontalTextAlignment = TextAlignment.Center
                    }
                }
            };
        }
    }
}
