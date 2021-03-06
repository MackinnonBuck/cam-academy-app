﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    /// <summary>
    /// Controls the master page and the content that the master page links to.
    /// </summary>
    public class MainPage : MasterDetailPage
    {
        MasterPage masterPage;

        /// <summary>
        /// Initializes a new MDPage instance.
        /// </summary>
        public MainPage()
        {
            masterPage = new MasterPage();
            masterPage.ListView.ItemSelected += ListViewItemSelected;
            Master = masterPage;
            Detail = new NavigationPage(new JunklessPage("Home", SiteAttributes.BaseUri))
            {
                BarBackgroundColor = CAMColors.Primary,
                BarTextColor = CAMColors.Accent
            };
        }

        /// <summary>
        /// When an item is selected from the master page's ListView, the corresponding page is opened.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            SelectableItem item = e.SelectedItem as SelectableItem;
            masterPage.ListView.SelectedItem = null;

            if (item == null || item.TargetType == null)
                return;

            Detail = new NavigationPage((Page)(item.Arguments == null ? Activator.CreateInstance(item.TargetType) : Activator.CreateInstance(item.TargetType, item.Arguments)))
            {
                BarBackgroundColor = CAMColors.Primary,
                BarTextColor = CAMColors.Accent
            };

            IsPresented = false;
        }
    }
}
