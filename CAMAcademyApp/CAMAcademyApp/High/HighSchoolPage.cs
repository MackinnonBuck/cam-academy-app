using CAMAcademyApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.High
{
    public class HighSchoolPage : TabbedPage
    {
        public HighSchoolPage()
        {
            Title = "High School";

            Children.Add(new HighSchoolAboutPage());
        }
    }
}
