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
        //public static ValueRange MenuValues { get; private set; }
        public static LinkNode RootNode { get; private set; }

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

            //MenuValues = request.Execute();

            RootNode = LinkNode.Generate(request.Execute());//LinkNode.Generate(MenuValues);

            MainPage = new MainPage();
        }

        void GenerateLinkTree(LinkNode node, int column)
        {

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
