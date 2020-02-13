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
            try
            {
                //create a instance of controlling
                controlling con = new controlling();

                //Create a new diary
                if (string.IsNullOrEmpty(txtDiaryName.Text))
                {
                    throw new Exception("Name missing");
                }
                else if (con.Diary_Exist(txtDiaryName.Text))
                {
                    throw new Exception($"Diary with the name {txtDiaryName.Text} already exists");
                }
                else
                {
                    int id = con.Create_Diary(txtDiaryName.Text, CurrentUsername);
                    if (id == -1)
                    {
                        throw new Exception("Could not create the diary");
                    }
                    con.Show_SearchWindow(id);
                    this.Close();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //create a instance of controlling
            controlling con = new controlling();

            //Get id of the diary
            if (cmbDiaries.SelectedItem != null)
            {
                e_Tagebuch_Context DB = new e_Tagebuch_Context();
                var diary = DB.Diaries.FirstOrDefault(d => d.Name == cmbDiaries.SelectedItem.ToString());
                con.Show_SearchWindow(diary.DiaryID);
                this.Hide();
            } else
            {
                MessageBox.Show("No diary is selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            

        }
    }
}
