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
    /// Interaction logic for frmDiaryElector.xaml
    /// </summary>
    public partial class frmDiaryElector : Window
    {
        string CurrentUsername;
        public frmDiaryElector(string t_CurrentUsername)
        {
            CurrentUsername = t_CurrentUsername;
            InitializeComponent();

            //Set combobox with diaries
            controlling con = new controlling();
            foreach (var diary in con.Get_AllDiaries())
            {
                cmbDiaries.Items.Add(diary);
            }

        }

        private void btnCreateDiary_Click(object sender, RoutedEventArgs e)
        {
            //create a instance of controlling
            controlling con = new controlling();

            //Create a new diary
            if (string.IsNullOrEmpty(txtDiaryName.Text))
            {
                MessageBox.Show("Name missing","Error",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
            else
            {
                int id = con.Create_Diary(txtDiaryName.Text, CurrentUsername);
                if (id == -1)
                {
                    throw new Exception("Could not create the diary");
                }
                con.Show_SearchWindow(id);
                this.Hide();
            }
        }
    }
}
