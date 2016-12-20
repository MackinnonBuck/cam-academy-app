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
    public class HighSchoolPage : SelectiveWebPage
    {
        public HighSchoolPage()
            : base("High School")
        {
            Load("http://cam.battlegroundps.org/high/profile", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
                new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            });
        }
    }
}
