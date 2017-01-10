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
        /// <summary>
        /// Initializes a new AutoPage with the given LinkNode.
        /// </summary>
        /// <param name="node"></param>
        public AutoPage(LinkNode node, int startPageIndex)
        {
            LinkNode childNode = node.Children[startPageIndex];

            Title = node.Name + " - " + childNode.Name;

            List<LinkNode> externalNodes = new List<LinkNode>();

            foreach (LinkNode grandchildNode in childNode.Children)
            {
                if (grandchildNode.Link.StartsWith(SiteAttributes.BaseUri))
                    Children.Add(new JunklessPage(grandchildNode.Name, grandchildNode.Link));
                else
                    externalNodes.Add(grandchildNode);
            }

            if (externalNodes.Count > 0)
                Children.Add(new LinksAndDocumentsPage(externalNodes));
        }
    }
}
