using CAMAcademyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.About
{
    public class SchoolProfilePage : TabbedPage
    {
        /*
         * TODO:
         * So turns out you can modify the children of a tabbed page. So just make this the new about page and
         * have the children be switchable with the toolbaritem.
         * Update:
         * At this point you can probably start working on the full auto-generation.
         */

        public SchoolProfilePage()
        {
            ToolbarItem testItem = new ToolbarItem
            {
                Text = "Test",
                Order = ToolbarItemOrder.Secondary
            };

            testItem.Clicked += TestItem_Clicked;
            ToolbarItems.Add(testItem);

            Title = "School Profile";

            Children.Add(new JunklessPage("History", "http://cam.battlegroundps.org/about/history"));

            Children.Add(new JunklessPage("Our Mission", "http://cam.battlegroundps.org/about/mission"));

            Children.Add(new JunklessPage("Primary School Profile", "http://cam.battlegroundps.org/primary/profile"));

            Children.Add(new JunklessPage("Middle School Profile", "http://cam.battlegroundps.org/middle/profile"));

            Children.Add(new JunklessPage("High School Profile", "http://cam.battlegroundps.org/high/profile"));

            Children.Add(new JunklessPage("A Day in the Life", "http://cam.battlegroundps.org/about/life"));

            Children.Add(new JunklessPage("Character Education", "http://cam.battlegroundps.org/about/character"));

            Children.Add(new JunklessPage("How Does CAM Compare?", "http://cam.battlegroundps.org/about/comparison"));

            //Children.Add(new JunklessPage("History", "http://cam.battlegroundps.org/about/history", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("Our Mission", "http://cam.battlegroundps.org/about/mission", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("Primary School Profile", "http://cam.battlegroundps.org/primary/profile", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("Middle School Profile", "http://cam.battlegroundps.org/middle/profile", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("High School Profile", "http://cam.battlegroundps.org/high/profile", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("A Day in the Life", "http://cam.battlegroundps.org/about/life", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("Character Education", "http://cam.battlegroundps.org/about/character", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));

            //Children.Add(new JunklessPage("How Does CAM Compare?", "http://cam.battlegroundps.org/about/comparison", new List<KeyValuePair<string, string>>
            //{
            //    new KeyValuePair<string, string>("class", "sites-layout-tile sites-tile-name-content-1"),
            //    new KeyValuePair<string, string>("style", "width:523px;background:#fff;border:1px solid #d7d7d7;display:block;float:left;padding-bottom:20px")
            //}));
        }

        private void TestItem_Clicked(object sender, EventArgs e)
        {
            Children.Clear();
        }
    }
}
