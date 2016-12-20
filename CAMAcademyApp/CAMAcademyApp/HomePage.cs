using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// The home page. Contains important information and updates.
    /// </summary>
    public class HomePage : SelectiveWebPage
    {
        public HomePage()
            : base("Home")
        {
            Load("http://cam.battlegroundps.org#", new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
                new KeyValuePair<string, string>("style", "background:rgb(255,255,255);border:0px solid rgb(215,215,215);width:523px;padding-bottom:20px;float:left;display:block")
            });
        }
    }
}
