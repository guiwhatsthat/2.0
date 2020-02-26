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
    /// Interaction logic for frmSearchWindow.xaml
    /// </summary>
    public partial class frmSearchWindow : Window
    {
        int DiaryID;
        List<int> DiaryViewList = new List<int>();
        public frmSearchWindow(int t_DiaryID)
        {
            DiaryID = t_DiaryID;
            InitializeComponent();
            //Add types to combobox
            e_Tagebuch_Context con = new e_Tagebuch_Context();
            foreach (var typ in con.Types)
            {
                cmbType.Items.Add(typ.Name);
            }

            //Set Current Diary in GUI
            var diary = con.Diaries.FirstOrDefault(d => d.DiaryID == DiaryID);
            txtTagebuch.Text = diary.Name;

            Update_EntryView();
        }

        private void bntNew_Click(object sender, RoutedEventArgs e)
        {
            //Create a new Entry
            controlling con = new controlling();
            int entryID = con.Create_Entry("New Entry", DiaryID);
            frmEditor editor = new frmEditor(entryID);
            editor.Show();
            this.Close();
        }

        private void BntClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Environment.Exit(0);
        }

        private void BntEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgView.SelectedItem != null)
                {
                    frmEditor editor = new frmEditor(DiaryViewList[dgView.SelectedIndex]);
                    editor.Show();
                    this.Close();
                }
            }
            catch {
                MessageBox.Show("You can not edit any empty day");
            }
        }

        private void bntRemove_Click(object sender, RoutedEventArgs e)
        {
            if (dgView.SelectedItem != null)
            {
                controlling con = new controlling();
                con.Remove_Entry(DiaryViewList[dgView.SelectedIndex]);
                Update_EntryView();
            }   
        }

        private void Update_EntryView ()
        {
            //Update list with all entries
            controlling control = new controlling();
            var allEntries = control.Get_AllEntries(DiaryID);
            if (allEntries != null)
            {
                dgView.ItemsSource = allEntries.Select(d => new {Name = d.Name, Date = d.Date , EntryID = d.EntryID });
                DiaryViewList = allEntries.Select(e => e.EntryID).ToList();
            }
        }

        //Function to control the search option
        public void Set_SearchElement (object sender, RoutedEventArgs e)
        {
            var list = (this.Content as Panel).Children.OfType<CheckBox>();
            foreach (var item in list) {
                var name = "";
                if (sender.GetType().Name == "CheckBox")
                {
                    name = ((CheckBox)sender).Name;
                }
                
                if (name != item.Name)
                {
                    item.IsChecked = false;
                } else
                {
                    txtSuche.Text = "";
                }
            }
        }

        private void bntShow_Click(object sender, RoutedEventArgs e)
        {
            controlling con = new controlling();

            if (!string.IsNullOrEmpty(txtSuche.Text))
            {
                dgView.ItemsSource = con.Search_Entries("Name", txtSuche.Text).Select(d => new { Name = d.Name, Date = d.Date, EntryID = d.EntryID });
            } else if (chkDate.IsChecked == true && dpSearchDate.SelectedDate != null)
            {
                dgView.ItemsSource = con.Search_Entries("Date", dpSearchDate.SelectedDate.ToString()).Select(d => new { Name = d.Name, Date = d.Date, EntryID = d.EntryID });
            } else if (chkType.IsChecked == true && cmbType.SelectedItem != null)
            {
                dgView.ItemsSource = con.Search_Entries("Type", cmbType.SelectedItem.ToString()).Select(d => new { Name = d.Name, Date = d.Date, EntryID = d.EntryID });
            } else if (chkdateSince .IsChecked == true && dpFrom.SelectedDate.HasValue == true && dpTo.SelectedDate.HasValue == true)
            {
                dgView.ItemsSource = con.Get_EmptyDays(dpFrom.SelectedDate.Value, dpTo.SelectedDate.Value);
            } 
        }

        private void bntClear_Click(object sender, RoutedEventArgs e)
        {
            Set_SearchElement(sender, e);
            Update_EntryView();
        }

        private void bntChange_Click(object sender, RoutedEventArgs e)
        {
            controlling con = new controlling();
            con.Show_Diary(DiaryID);
            this.Close();
        }
    }
}
