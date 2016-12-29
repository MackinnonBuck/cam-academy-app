using CAMAcademyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.High
{
    /// <summary>
    /// The high school page. Contains an overview of the high school.
    /// </summary>
    public class HighSchoolAboutPage : TabbedPage
    {
        /// <summary>
        /// Initializes the page.
        /// </summary>
        public HighSchoolAboutPage()
        {
            Title = "About Us";

            //Children.Add(new JunklessPage("High School Profile", "http://cam.battlegroundps.org/high/profile", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("High School Teachers", "http://cam.battlegroundps.org/high/teachers", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:958px;background:#ffffff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //AddSubpage(new Subpage
            //{
            //    Title = "High School Profile",
            //    BaseUri = "http://cam.battlegroundps.org/high/profile",
            //    AttributesList = new List<KeyValuePair<string, string>>
            //    {
            //        new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //        new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //    }
            //});

            //AddSubpage(new Subpage
            //{
            //    Title = "High School Teachers",
            //    BaseUri = "http://cam.battlegroundps.org/high/teachers",
            //    AttributesList = new List<KeyValuePair<string, string>>
            //    {
            //        new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //        new KeyValuePair<string, string>("style", "width:958px;background:#ffffff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //    }
            //});

            //LoadSubpage("High School Profile");
        }
    }
}
