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
            SheetsService service = new SheetsService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyBCjx3dXFHWd5hdm0CyQMRxYBeokxE9brU",
                ApplicationName = "CAM Academy App"
            });

            SpreadsheetsResource.ValuesResource.GetRequest request = service.Spreadsheets.Values.Get(
                "1nBjpqKNkDyyWw4OwvI_pb05lhRdpkSLJRRqwnbhmxv4",
                "A2:F");

            RootNode = LinkNode.Generate(request.Execute());

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
