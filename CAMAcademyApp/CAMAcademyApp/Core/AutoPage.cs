using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace CAMAcademyApp.Core
{
    public class AutoPage : TabbedPage
    {
        private LinkNode pageNode;

        /// <summary>
        /// Initializes a new AutoPage with the given LinkNode.
        /// </summary>
        /// <param name="node"></param>
        public AutoPage(LinkNode node, int startPageIndex)
        {
            pageNode = node;

            foreach (LinkNode childNode in pageNode.Children)
            {
                ToolbarItem item = new ToolbarItem
                {
                    Order = ToolbarItemOrder.Secondary,
                    Text = childNode.Name
                };

                item.Clicked += ToolbarItemClicked;
                ToolbarItems.Add(item);
            }

            SetPage(node.Children[startPageIndex]);
        }

        /// <summary>
        /// Changes the webpage section based on what ToolbarItem was clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolbarItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;

            LinkNode itemNode = pageNode.Children[ToolbarItems.IndexOf(item)];

            SetPage(pageNode.Children[ToolbarItems.IndexOf(item)]);
        }

        /// <summary>
        /// Sets the page from the given pageIndex and the optional subpageIndex.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="subpageIndex"></param>
        private void SetPage(LinkNode node)
        {
            Children.Clear();

            Title = pageNode.Name + " - " + node.Name;

            List<LinkNode> externalNodes = new List<LinkNode>();

            foreach (LinkNode childNode in node.Children)
            {
                if (childNode.Link.StartsWith(SiteAttributes.BaseUri))
                    Children.Add(new JunklessPage(childNode.Name, childNode.Link));
                else
                    externalNodes.Add(childNode);
            }

            if (externalNodes.Count > 0)
                Children.Add(new LinksAndDocumentsPage(externalNodes));
        }
    }
}
