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

            //Update list with all entries
            controlling control = new controlling();
            var allEntries = control.Get_AllEntries(DiaryID);
            if (allEntries != null)
            {
                foreach (var cEntry in allEntries)
                {
                    var row = new { Name = cEntry.Name, Datum = cEntry.Date.Date, Domaene = cEntry.Type, Text = cEntry.Text, Bildpfad = cEntry.Picture };
                    lvwView.Items.Add(row);
                }
            }
        }

        private void bntNew_Click(object sender, RoutedEventArgs e)
        {
            //Create a new Entry
            controlling con = new controlling();
            int entryID = con.Create_Entry("New Entry", DiaryID);
            frmEditor editor = new frmEditor(entryID);
            editor.Show();
            this.Hide();
        }
    }
}
