using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CAMAcademyApp
{
    /// <summary>
    /// A SelectiveWebPage with a list to pick between various subpages.
    /// </summary>
    public class MultiSelectiveWebPage : SelectiveWebPage
    {
        private ToolbarItem sectionButton;
        private Picker sectionPicker;

        /// <summary>
        /// Describes an individual subpage.
        /// </summary>
        public struct Subpage
        {
            public string Title;
            public string BaseUri;
            public List<KeyValuePair<string, string>> AttributesList;
        }

        private List<Subpage> subpages;

        /// <summary>
        /// Initializes a new MultiSelectiveWebPage.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="pages"></param>
        public MultiSelectiveWebPage(string title)
            : base(title)
        {
            subpages = new List<Subpage>();

            sectionPicker = new Picker
            {
                Title = title,
                IsVisible = false
            };

            foreach (Subpage page in subpages)
                sectionPicker.Items.Add(page.Title);

            sectionPicker.SelectedIndexChanged += SectionPickerIndexChanged;
            StackLayout.Children.Add(sectionPicker);

            sectionButton = new ToolbarItem();
            sectionButton.Icon = new FileImageSource
            {
                File = "ic_arrow_drop_down_white_24dp.png"
            };
            sectionButton.Clicked += SelectionButtonClicked;
            ToolbarItems.Add(sectionButton);
        }

        /// <summary>
        /// Adds a subpage to the list of registered subpages.
        /// </summary>
        /// <param name="subpage"></param>
        public void AddSubpage(Subpage subpage)
        {
            sectionPicker.Items.Add(subpage.Title);
            subpages.Add(subpage);
        }

        /// <summary>
        /// Loads a subpage with the specified index, if given. Otherwise, loads the first subpage.
        /// </summary>
        /// <param name="subpageIndex"></param>
        public void LoadSubpage(int subpageIndex = 0)
        {
            if (subpages.Count == 0)
                return;

            Subpage currentPage = subpages[subpageIndex];
            Title = currentPage.Title;
            Load(currentPage.BaseUri, currentPage.AttributesList);
        }

        /// <summary>
        /// Reloads the proper subpage when a new option is selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SectionPickerIndexChanged(object sender, EventArgs e)
        {
            LoadSubpage(sectionPicker.SelectedIndex);
        }

        /// <summary>
        /// Shows the selection picker when the selection button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionButtonClicked(object sender, EventArgs e)
        {
            sectionPicker.Focus();
        }
    }
}
