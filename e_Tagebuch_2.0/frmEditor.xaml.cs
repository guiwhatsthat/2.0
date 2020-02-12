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
    /// Interaction logic for frmEditor.xaml
    /// </summary>
    public partial class frmEditor : Window
    {
        int EntryID;
        public frmEditor(int t_EntryID)
        {
            EntryID = t_EntryID;
            InitializeComponent();
            //Fill form elements
            e_Tagebuch_Context con = new e_Tagebuch_Context();
            var entry = con.Entries.FirstOrDefault(e => e.EntryID == EntryID);
            txtName.Text = entry.Name;
            txtMain.Text = entry.Text;
            lblPicPath.Content = entry.Picture;
            if (entry.Date == null)
            {
                dpDatepicker.DisplayDate = DateTime.Now;
            } else
            {
                dpDatepicker.DisplayDate = entry.Date;
            }
                
        }
    }
}
