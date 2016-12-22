using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// The high school page. Contains an overview of the high school.
    /// </summary>
    public class HighSchoolPage : MultiSelectiveWebPage
    {
        /// <summary>
        /// Initializes the page.
        /// </summary>
        public HighSchoolPage()
            : base("High School")
        {
            AddSubpage(new Subpage
            {
                Title = "High School Profile",
                BaseUri = "http://cam.battlegroundps.org/high/profile",
                AttributesList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
                    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
                }
            });

            AddSubpage(new Subpage
            {
                Title = "High School Teachers",
                BaseUri = "http://cam.battlegroundps.org/high/teachers",
                AttributesList = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
                    new KeyValuePair<string, string>("style", "width:958px;background:#ffffff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
                }
            });

            LoadSubpage();
        }
    }
}
