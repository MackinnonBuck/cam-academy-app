using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static CAMAcademyApp.Core.Extensions;
using static CAMAcademyApp.Core.FormattedLayout;

namespace CAMAcademyApp.Core
{
    public class NativeWebPage : ScrollView
    {
        /*
         * TODO: You have the text styling and generation down pat.
         * Now it's time to group things properly.
         * As of the time I wrote this I was thinking the best idea
         * was to by default group elements together in a WrapLayout
         * instead of adding them to the StackLayout.
         * If there's an element that hints at a break (e.g. a <p> or
         * the end of a <font> element with a bunch of sub-elements),
         * then it creates a new WrapLayout and starts adding stuff
         * to that.
         */

        // TODO (v2): It would be nice to have one label with a bunch
        // of spans for different styles. But to do that, you have to figure
        // out a way to detect touches on individual spans.

        /*
         * TODO (v3): So I guess it's not easy to detect span clicks.
         * What I would reccomend is implementing a text measurement
         * system (or find one that's been implemented), and having a system
         * somewhat similar to placing entire labels one after another in
         * a WrapLayout. But, since multiline labels are discontinuous with
         * their descendants, you could have a check to see if the label
         * would extend beyond the WrapLayout bounds, and if it does,
         * split the label into two different labels. Also figure out
         * a way to optimize the OnMeasure() method in WrapLayout
         * so switching tabs doesn't screw over the UI thread (which
         * shouldn't be *as* much of an issue since there will be fewer
         * labels after this change anyway, but still).
         */

        private StackLayout StackLayout { get { return Content as StackLayout; } }

        private bool generated;
        private HtmlNode node;
        private FormattedLayout activeLayout;

        public NativeWebPage(HtmlNode node)
        {
            generated = false;
            this.node = node;

            Content = new StackLayout
            {
                Padding = new Thickness(8.0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            Content.SizeChanged += StackLayout_SizeChanged;

            activeLayout = new FormattedLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                //VerticalSpacing = 4.0
            };

            // TODO: Size changed event handler?
        }

        private void StackLayout_SizeChanged(object sender, EventArgs e)
        {
            if (!generated)
            {
                generated = true;
                GenerateChildren(node);
                activeLayout.GenerateChildren(StackLayout.Width);
                StackLayout.Children.Add(activeLayout);
            }
        }

        private void GenerateChildren(HtmlNode node)
        {
            foreach (HtmlNode child in node.ChildNodes)
            {
                if (child.IsCData())
                {
                    //foreach (string word in child.InnerText.Split(' '))
                    //{
                    //Label label = new Label();
                    PseudoLabel label = new PseudoLabel();

                    foreach (HtmlNode parent in child.Ancestors())
                    {
                        MethodInfo handler = GetType().GetTypeInfo().GetDeclaredMethod("Str_" + parent.Name);
                        handler?.Invoke(this, new object[] { parent, child.InnerText, label });
                    }

                    activeLayout.Labels.Add(label);
                    //activeLayout.Children.Add(label);
                    //}
                }
                else
                {
                    MethodInfo handler = GetType().GetTypeInfo().GetDeclaredMethod("Elem_" + child.Name);

                    if (handler == null)
                    {
                        if (child.ChildNodes.Count > 0)
                            GenerateChildren(child);
                    }
                    else
                    {
                        handler.Invoke(this, new object[] { child });
                    }
                }
            }
        }

        //private void Elem_hr(HtmlNode node)
        //{
        //    BoxView boxView = new BoxView
        //    {
        //        Margin = new Thickness(0, 12),
        //        HeightRequest = 1,
        //        Color = Color.Gray
        //    };

        //    StackLayout.Children.Add(boxView);
        //}

        private void Str_font(HtmlNode node, string text, PseudoLabel label)
        {
            label.Text = text;
            label.TextColor = Color.White;
            
            HtmlAttribute fontSize = node.Attributes["size"];

            if (fontSize != null)
                label.FontSize = Device.GetNamedSize((NamedSize)int.Parse(fontSize.Value), typeof(Label));
        }

        private void Str_h2(HtmlNode node, string text, PseudoLabel label)
        {
            label.Text = text.ToUpper();
            label.TextColor = Color.White;
            label.FontAttributes = FontAttributes.Bold;
        }

        private void Str_h3(HtmlNode node, string text, PseudoLabel label)
        {
            label.Text = text;
            label.TextColor = Color.White;
        }

        private void Str_span(HtmlNode node, string text, PseudoLabel label)
        {
            label.Text = text;
            label.TextColor = Color.White;

            Stylesheet stylesheet = node.GetStylesheet();

            if (stylesheet != null)
            {
                if (stylesheet.Styles.ContainsKey("font-size"))
                {
                    NamedSize fontSize = NamedSize.Default;

                    switch (stylesheet.Styles["font-size"])
                    {
                        case "medium":
                            fontSize = NamedSize.Medium;
                            break;
                        case "xx-small":
                        case "x-small":
                        case "small":
                            fontSize = NamedSize.Small;
                            break;
                        case "large":
                        case "x-large":
                        case "xx-large":
                            fontSize = NamedSize.Large;
                            break;
                    }

                    label.FontSize = Device.GetNamedSize(fontSize, typeof(Label));
                }
            }
        }
    }
}
