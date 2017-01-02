using CAMAcademyApp.Core;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp
{
    public class App : Application
    {
        /// <summary>
        /// The root LinkNode containing information regarding the navigation menu names and links.
        /// </summary>
        public static LinkNode RootNode { get; private set; }

        /// <summary>
        /// Initializes the App instance.
        /// </summary>
        public App()
        {
            MainPage = new SplashScreen();
        }

        /// <summary>
        /// Fixes any strange name casing for the child nodes and removes any nodes that don't have parents.
        /// </summary>
        /// <param name="node"></param>
        private void CleanNode(LinkNode node)
        {
            List<LinkNode> invalidNodes = new List<LinkNode>();

            foreach (LinkNode childNode in node.Children)
            {
                if (childNode.Children.Count == 0)
                    invalidNodes.Add(childNode);
                else
                    childNode.Name = childNode.Name.ToTitleCase();
            }

            foreach (LinkNode invalidNode in invalidNodes)
                node.Children.Remove(invalidNode);
        }

        /// <summary>
        /// Reads from the Google Spreadsheet to generate data used in the interface.
        /// </summary>
        private void GenerateUserInterface()
        {
            SheetsService service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyBCjx3dXFHWd5hdm0CyQMRxYBeokxE9brU",
                ApplicationName = "CAM Academy App"
            });

            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(
                "1nBjpqKNkDyyWw4OwvI_pb05lhRdpkSLJRRqwnbhmxv4",
                "A2:F");

            RootNode = LinkNode.Generate(request.Execute());

            CleanNode(RootNode);

            foreach (LinkNode childNode in RootNode.Children)
                CleanNode(childNode);
        }

        /// <summary>
        /// Generates the user interface and displays the main page.
        /// </summary>
        protected override void OnStart()
        {
            Task.Run(() => GenerateUserInterface()).ContinueWith((x) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    MainPage = new MainPage();
                });
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
