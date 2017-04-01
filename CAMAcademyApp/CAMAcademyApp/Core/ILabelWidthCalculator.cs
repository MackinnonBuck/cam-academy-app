using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp.Core
{
    public interface ILabelWidthCalculator
    {
        void SetFont(string fontFamily, float fontSize, bool isBold);
        Size Calculate(string text);
    }
}
