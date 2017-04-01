using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class FormattedLayout : Layout<FormattedLayout.LockedLabel>
    {
        public class PseudoLabel
        {
            public string Text { get; set; }
            public Color TextColor { get; set; }
            public FontAttributes FontAttributes { get; set; }
            public double FontSize { get; set; }
        }

        public class LockedLabel : Label
        {
            public double AbsoluteX { get; set; }
            public double AbsoluteY { get; set; }
            public double AbsoluteWidth { get; set; }
            public double AbsoluteHeight { get; set; }

            public LockedLabel(PseudoLabel label)
            {
                Text = label.Text;
                TextColor = label.TextColor;
                FontAttributes = label.FontAttributes;
                FontSize = label.FontSize;
            }
        }

        public List<PseudoLabel> Labels { get; private set; }

        private ILabelWidthCalculator calculator;

        public FormattedLayout()
        {
            Labels = new List<PseudoLabel>();
            calculator = DependencyService.Get<ILabelWidthCalculator>();
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            if (Children.Count == 0)
                return new SizeRequest(Size.Zero);

            LockedLabel lastLabel = Children.Last();
            return new SizeRequest(new Size(widthConstraint, lastLabel.AbsoluteY + lastLabel.Height));
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            foreach (LockedLabel child in Children)
                LayoutChildIntoBoundingRegion(child, new Rectangle(child.AbsoluteX, child.AbsoluteY, child.AbsoluteWidth, child.AbsoluteHeight));
        }

        public void GenerateChildren(double width)
        {
            // TODO: Take best of old and new. Measuring labels doesn't work, and if it did, performance would suck. But new logic and structures should work better.

            double x = 0.0;
            double y = 0.0;
            double rowHeight = 0.0;

            foreach (PseudoLabel pl in Labels)
            {
                LockedLabel label = new LockedLabel(pl);

                SizeRequest request = label.Measure(double.PositiveInfinity, double.PositiveInfinity);

                double labelWidth = request.Request.Width;
                double labelHeight = request.Request.Height;
                rowHeight = Math.Max(rowHeight, labelHeight);

                bool canSplit = true;

                while (canSplit && x + labelWidth > width)
                {
                    LockedLabel subLabel = new LockedLabel(pl);

                    double sectionWidth = labelWidth;

                    while (x + sectionWidth > width)
                    {
                        int spaceIndex = subLabel.Text.LastIndexOf(' ');

                        if (spaceIndex == -1)
                        {
                            canSplit = false;
                            break;
                        }

                        subLabel.Text = subLabel.Text.Remove(subLabel.Text.LastIndexOf(' '));
                        sectionWidth = subLabel.Measure(double.PositiveInfinity, double.NegativeInfinity).Request.Width;
                    }

                    if (canSplit)
                    {
                        subLabel.AbsoluteX = x;
                        subLabel.AbsoluteY = y;
                        subLabel.AbsoluteWidth = sectionWidth;
                        subLabel.AbsoluteHeight = labelHeight;

                        Children.Add(label);
                    }

                    x = 0;
                    y += labelHeight;
                    rowHeight = labelHeight;
                    labelWidth -= sectionWidth;
                }

                label.Text = pl.Text;
                label.AbsoluteX = x;
                label.AbsoluteY = y;
                label.AbsoluteWidth = labelWidth;
                label.AbsoluteHeight = labelHeight;

                Children.Add(label);

                x += labelWidth;
            }
        }

        //public void GenerateChildren(double width)
        //{
        //    double x = 0.0;
        //    double y = 0.0;
        //    double rowHeight = 0.0;

        //    foreach (Span span in Spans)
        //    {
        //        // TODO: Maybe try to measure the labels directly to determine the size?

        //        calculator.SetFont(span.FontFamily, (float)span.FontSize, span.FontAttributes.HasFlag(FontAttributes.Bold));
        //        Size size = calculator.Calculate(span.Text);

        //        double textWidth = size.Width;
        //        double textHeight = size.Height;
        //        rowHeight = Math.Max(rowHeight, textHeight);

        //        while (x + textWidth > width)
        //        {
        //            double labelWidth = textWidth;

        //            string trimmedText = span.Text;

        //            while (x + labelWidth > width)
        //            {
        //                if (trimmedText.IndexOf(' ') == -1)
        //                    break;

        //                labelWidth = calculator.Calculate(trimmedText = trimmedText.Remove(trimmedText.LastIndexOf(' '))).Width;
        //            }

        //            string remainingText = span.Text.Substring(trimmedText.Length);

        //            span.Text = trimmedText;
        //            AddLabel(span, x, y, labelWidth, textHeight);
        //            span.Text = remainingText;

        //            x = 0;
        //            y += rowHeight;
        //            rowHeight = textHeight;
        //            textWidth -= labelWidth;
        //        }

        //        AddLabel(span, x, y, textWidth, textHeight);

        //        x += textWidth;
        //    }
        //}

        //void AddLabel(Span span, double x, double y, double width, double height)
        //{
        //    FormattedString fs = new FormattedString();
        //    fs.Spans.Add(span);

        //    Children.Add(new LockedLabel
        //    {
        //        FormattedText = fs,
        //        AbsoluteX = x,
        //        AbsoluteY = y,
        //        AbsoluteWidth = width,
        //        AbsoluteHeight = height
        //    });
        //}
    }
}
