using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/*
 * TODO: Okay, so here's the deal:
 * Turns out the actual menu is JavaScript generated. Should've guessed though tbh. You can get really close and get the div surrounding the
 * menu items but can't get access to anything inside it. So.
 * I would look into using something like WebKit.NET. It will allow you to load the page and get the JavaScript-generated HTML in a few lines of code.
 */

namespace CAMAcademyApp.Core
{
    public class AutoPage : TabbedPage
    {
        public AutoPage(string title, int startIndex, int endIndex)
        {
            Title = title;
            
            IsBusy = true; // TODO: This should trigger the activity indicator but doesn't. Fix.


            //Task.Run(() => SiteUtils.GenerateHtmlDocument(SiteInfo.HomePageUri)).ContinueWith((x) => ParseSection(x.Result));
        }

        //public void ParseSection(HtmlDocument document)
        //{
        //    HtmlNode iframeNode = SiteUtils.FindNode(document.DocumentNode, "iframe", new KeyValuePair<string, string>("class", "igm"));

        //    if (iframeNode == null)
        //        return; // TODO: Handle a case in which null is returned.

        //    string iframeSource = "http:" + iframeNode.Attributes["src"].Value;

        //    HtmlDocument embeddedDocument = Task.Run(() => SiteUtils.GenerateHtmlDocument(iframeSource)).Result;
            
        //    //HtmlNode node = SiteUtils.FindNode(document.DocumentNode, "div", new KeyValuePair<string, string>("class", "mainNav"));

        //    //IWebSourceLoader sourceLoader = DependencyService.Get<IWebSourceLoader>();
        //    //sourceLoader.LoadFromUri(SiteInfo.HomePageUri);
        //}
    }
}
