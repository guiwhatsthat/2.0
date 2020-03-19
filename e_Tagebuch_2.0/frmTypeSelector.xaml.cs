using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace e_Tagebuch_2._0
{
    /// <summary>
    /// Interaction logic for frmTypeSelector.xaml
    /// </summary>
    public partial class frmTypeSelector : Window
    {
        int entryID;
        public frmTypeSelector(int t_EntryID)
        {
            entryID = t_EntryID;
            InitializeComponent();

            //get current typ and set gui elements
            controlling con = new controlling();
            var types = con.Get_types(entryID);
            if (types != null)
            {
                foreach (string name in types)
                {
                    foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children)
                    {
                        if ((types.Any(n => n == CheckBoxDomaene.Content.ToString())))
                        {
                            CheckBoxDomaene.IsChecked = true;
                        }
                    }
                }
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            //Function that ensures that no more than three types are selected
            CheckBox ClickedCheckbox = (CheckBox)sender;
            List<CheckBox> AlleDomaenen = new List<CheckBox>();
            foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children)
            {
                AlleDomaenen.Add(CheckBoxDomaene);
            }
            if ((AlleDomaenen.FindAll(Box => Box.IsChecked == true)).Count > 3)
            {
                ClickedCheckbox.IsChecked = false;
                MessageBox.Show("Not more than 3 types can be selected at the same time", "e_Tagenbuch", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                ClickedCheckbox.IsChecked = true;
            }
        }

        private void BntOk_Click(object sender, RoutedEventArgs e)
        {
            //Save the types
            controlling con = new controlling();
            System.Collections.ArrayList selected = new System.Collections.ArrayList();
            foreach (CheckBox CheckBoxDomaene in GridCheckBox.Children)
            {
                if (CheckBoxDomaene.IsChecked == true)
                {
                    selected.Add(CheckBoxDomaene.Content.ToString());
                }
            }
            con.Save_types(entryID, (string[])selected.ToArray(typeof(string)));
            this.Close();
        }
    }
}
