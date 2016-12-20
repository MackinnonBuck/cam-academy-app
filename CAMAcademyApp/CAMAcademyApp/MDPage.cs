using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// Controls the master page and the content that the master page links to.
    /// </summary>
    public class MDPage : MasterDetailPage
    {
        MPage masterPage;

        /// <summary>
        /// Initializes a new MDPage instance.
        /// </summary>
        public MDPage()
        {
            masterPage = new MPage();
            masterPage.ListView.ItemSelected += ListView_ItemSelected;
            Master = masterPage;
            Detail = new NavigationPage(new HomePage());
        }

        /// <summary>
        /// When an item is selected from the master page's ListView, the corresponding page is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            MPageItem item = (MPageItem)e.SelectedItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            masterPage.ListView.SelectedItem = null;
            IsPresented = false;
        }
    }
}
