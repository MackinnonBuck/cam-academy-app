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
using CAMAcademyApp.Core;
using Xamarin.Forms;
using CAMAcademyApp.Droid;

[assembly: Dependency(typeof(LabelWidthCalculator))]
namespace CAMAcademyApp.Droid
{
    public class LabelWidthCalculator : ILabelWidthCalculator
    {
        private Android.Graphics.Paint paint;

        public LabelWidthCalculator()
        {
            paint = new Android.Graphics.Paint();
        }

        public Size Calculate(string text)
        {
            Android.Graphics.Rect bounds = new Android.Graphics.Rect();

            paint.GetTextBounds(text, 0, text.Length, bounds);

            return new Size(bounds.Width(), bounds.Height());
        }

        public void SetFont(string fontFamily, float fontSize, bool isBold)
        {
            paint.SetTypeface(Android.Graphics.Typeface.Create(fontFamily, isBold ?
                Android.Graphics.TypefaceStyle.Bold : Android.Graphics.TypefaceStyle.Normal));
            paint.TextSize = fontSize;
        }
    }
}