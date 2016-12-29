using CAMAcademyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.About
{
    public class StaffPage : TabbedPage
    {
        public StaffPage()
        {
            Title = "Staff";

            //Children.Add(new JunklessPage("Principal ~ Ryan Cowl", "http://cam.battlegroundps.org/about/cowl", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:958px;background:#ffffff;border:1px solid #2165a1;display:block;float:left;padding-bottom:20px")
            //}));
            //AddSubpage(new Subpage
            //{
            //    Title = "Principal ~ Ryan Cowl",
            //    BaseUri = "http://cam.battlegroundps.org/about/cowl",
            //    AttributesList = new List<KeyValuePair<string, string>>
            //    {
            //        new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //        new KeyValuePair<string, string>("style", "width:958px;background:#ffffff;border:1px solid #2165a1;display:block;float:left;padding-bottom:20px")
            //    }
            //});

            //LoadSubpage("Principal ~ Ryan Cowl");
        }
    }
}
