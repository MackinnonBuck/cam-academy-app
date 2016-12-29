using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// A SelectiveWebPage with a list to pick between various subpages.
    /// </summary>
    public class TabbedSelectiveWebPage : TabbedPage
    {
        //private Dictionary<string, Subpage> subpages;

        /// <summary>
        /// Initializes a new MultiSelectiveWebPage.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="pages"></param>
        public TabbedSelectiveWebPage(string title)
        {
            //subpages = new Dictionary<string, Subpage>();
        }

        /// <summary>
        /// Adds a subpage to the list of registered subpages.
        /// </summary>
        /// <param name="subpage"></param>
        public void AddPage(JunklessPage page)
        {
            //subpages.Add(subpage.Title, subpage);
            Children.Add(page);

            //ToolbarItem sectionButton = new ToolbarItem
            //{
            //    Text = subpage.Title,
            //    Order = ToolbarItemOrder.Secondary
            //};

            //sectionButton.Clicked += SectionButtonClicked;
            //ToolbarItems.Add(sectionButton);
        }

        /// <summary>
        /// Loads a subpage with the specified index, if given. Otherwise, loads the first subpage.
        /// </summary>
        /// <param name="subpageIndex"></param>
        //public void LoadSubpage(string subpageTitle)
        //{
        //    if (subpages.Count == 0)
        //        return;

        //    Subpage currentPage = subpages[subpageTitle];

        //    Page parentPage = Parent as Page;

        //    if (parentPage != null)
        //        parentPage.Title = currentPage.Title;

        //    Load(currentPage.BaseUri, currentPage.AttributesList);
        //}

        ///// <summary>
        ///// Shows the selection picker when the selection button is clicked.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void SectionButtonClicked(object sender, EventArgs e)
        //{
        //    LoadSubpage(((ToolbarItem)sender).Text);
        //}
    }
}
