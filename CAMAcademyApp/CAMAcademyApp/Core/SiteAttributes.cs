using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAMAcademyApp.Core
{
    public static class SiteAttributes
    {
        /// <summary>
        /// The home page of the CAM Academy website.
        /// </summary>
        public const string BaseUri = "http://cam.battlegroundps.org";

        /// <summary>
        /// Used to determine the main content tag of the website.
        /// </summary>
        public const string ContentClassName = "sites-layout-tile sites-tile-name-content-1";

        /// <summary>
        /// Used to determine which tag has the informational section.
        /// </summary>
        public static readonly string[] ContentStyleAttributes =
        {
            "background:rgb(255,255,255);border:0px solid rgb(215,215,215);width:523px;padding-bottom:20px;float:left;display:block",
            "display:block;float:left;padding-bottom:20px",
        };
    }
}
