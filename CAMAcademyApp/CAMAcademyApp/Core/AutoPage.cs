using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public class AutoPage : TabbedPage
    {
        private LinkNode pageNode;

        /// <summary>
        /// Initializes a new AutoPage with the given LinkNode.
        /// </summary>
        /// <param name="node"></param>
        public AutoPage(LinkNode node)
        {
            pageNode = node;

            foreach (LinkNode childNode in pageNode.Children)
            {
                ToolbarItem item = new ToolbarItem
                {
                    Order = ToolbarItemOrder.Secondary,
                    Text = childNode.Name.ToTitleCase()
                };

                item.Clicked += ToolbarItemClicked;
                ToolbarItems.Add(item);
            }

            if (ToolbarItems.Count > 0)
                ToolbarItemClicked(ToolbarItems[0], EventArgs.Empty);
        }

        /// <summary>
        /// Changes the webpage section based on what ToolbarItem was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarItemClicked(object sender, EventArgs e)
        {
            Children.Clear();

            ToolbarItem item = (ToolbarItem)sender;

            LinkNode itemNode = pageNode.Children[ToolbarItems.IndexOf(item)];

            Title = pageNode.Name.ToTitleCase() + " - " + itemNode.Name.ToTitleCase();

            List<LinkNode> externalNodes = new List<LinkNode>();

            foreach (LinkNode childNode in itemNode.Children)
            {
                if (childNode.Link.StartsWith(SiteAttributes.BaseUri))
                    Children.Add(new JunklessPage(childNode.Name.ToTitleCase(), childNode.Link));
                else
                    externalNodes.Add(childNode);
            }

            if (externalNodes.Count > 0)
                Children.Add(new ExternalResourcesPage(externalNodes));
        }
    }
}
