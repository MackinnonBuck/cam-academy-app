using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class WrapLayout : Layout<View>
    {
        class Row : List<Rectangle>
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }

        public static readonly BindableProperty HorizontalSpacingProperty =
            BindableProperty.Create(nameof(HorizontalSpacing), typeof(double), typeof(WrapLayout),
                0.0, propertyChanged: OnSpacingChanged);

        public static readonly BindableProperty VerticalSpacingProperty =
            BindableProperty.Create(nameof(VerticalSpacing), typeof(double), typeof(WrapLayout),
                0.0, propertyChanged: OnSpacingChanged);

        private static void OnSpacingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            WrapLayout layout = (WrapLayout)bindable;
            layout.InvalidateMeasure();
        }

        public double HorizontalSpacing
        {
            set { SetValue(HorizontalSpacingProperty, value); }
            get { return (double)GetValue(HorizontalSpacingProperty); }
        }

        public double VerticalSpacing
        {
            set { SetValue(VerticalSpacingProperty, value); }
            get { return (double)GetValue(VerticalSpacingProperty); }
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            List<Row> layout = ComputeNativeLayout(widthConstraint, heightConstraint);
            double width = layout.Max(row => row.Width);
            Row last = layout[layout.Count - 1];
            double height = last[0].Y + last.Height;

            return new SizeRequest(new Size(width, height));
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var layout = ComputeLayout(width, height);
            int i = 0;

            foreach (Rectangle region in layout)
            {
                var child = Children[i];
                i++;
                LayoutChildIntoBoundingRegion(child, region);
            }
        }

        private IEnumerable<Rectangle> ComputeLayout(double widthConstraint, double heightConstraint)
        {
            List<Row> layout = ComputeNativeLayout(widthConstraint, heightConstraint);
            return layout.SelectMany(s => s);
        }

        private List<Row> ComputeNativeLayout(double widthConstraint, double heightConstraint)
        {
            List<Row> result = new List<Row>();
            Row row = new Row();
            result.Add(row);

            double horizontalSpacing = HorizontalSpacing;
            double verticalSpacing = VerticalSpacing;
            double y = 0.0;

            foreach (View child in Children)
            {
                SizeRequest request = child.Measure(widthConstraint, double.PositiveInfinity);

                if (row.Count == 0)
                {
                    row.Add(new Rectangle(0, y, request.Request.Width, request.Request.Height));
                    row.Height = request.Request.Height;
                    continue;
                }

                Rectangle last = row[row.Count - 1];
                double x = last.Right + horizontalSpacing;
                double childWidth = request.Request.Width;
                double childHeight = request.Request.Height;

                if (x + childWidth > widthConstraint)
                {
                    y += row.Height + verticalSpacing;

                    row = new Row();
                    result.Add(row);
                    x = 0;
                }
                
                row.Add(new Rectangle(x, y, childWidth, childHeight));
                row.Width = x + childWidth;
                row.Height = Math.Max(row.Height, childHeight);
            }

            return result;
        }
    }
}