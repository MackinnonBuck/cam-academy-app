using CAMAcademyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace CAMAcademyApp.About
{
    public class AboutPage : TabbedPage
    {
        public AboutPage()
        {
            Children.Add(new SchoolProfilePage());
            Children.Add(new StaffPage());

            PropertyChanged += PagePropertyChanged;
            // TODO: Change it so the primary tabs come up in the toolbar and the secondary are switchable with the tabview.
        }

        private void PagePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentPage")
                Title = CurrentPage.Title;
        }
    }
}
