using CAMAcademyApp.Core;
using CAMAcademyApp.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(LabelWidthCalculator))]
namespace CAMAcademyApp.iOS
{
    public class LabelWidthCalculator : ILabelWidthCalculator
    {
        private UIStringAttributes stringAttributes;

        public Size Calculate(string text)
        {
            if (stringAttributes == null)
                return Size.Zero;

            NSString nsString = new NSString(text);
            CoreGraphics.CGSize size = nsString.GetSizeUsingAttributes(stringAttributes);

            return new Size(size.Width, size.Height);
        }

        public void SetFont(string fontFamily, float fontSize, bool isBold)
        {
            stringAttributes = new UIStringAttributes
            {
                Font = UIFont.FromName(isBold ?
                    fontFamily + "-Bold" : fontFamily, fontSize)
            };
        }
    }
}
