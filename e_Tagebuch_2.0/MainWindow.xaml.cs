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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace e_Tagebuch_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Create first user, only when no other user exists in DB
            e_Tagebuch_Context DB = new e_Tagebuch_Context();
            if (!DB.Users.Any())
            {
                controlling con = new controlling();
                con.Create_User("User", "Password");
            }

            //Create all possible types
            string[] Types = new string[]{ "Work", "Family", "Holidays", "Birthday", "School"};
            foreach (string typeName in Types)
            {
                if (!DB.Types.Any(t => t.Name == typeName))
                {
                    DB.Types.Add(new Type()
                    {
                        Name = typeName
                    });
                }
            }
            DB.SaveChanges();
        }

        private void bntLogin_Click(object sender, RoutedEventArgs e)
        {
            //Check if the user logi
            controlling con = new controlling();
            int ID = 0;
            bool openForm = false;

            if (rbnNewUser.IsChecked.Value) 
            {
                //Create User
                ID = (con.Create_User(txtUsername.Text, txtPassword.Password)).UserID;
                openForm = true;
            } else
            {
                var user = con.Check_Credential(txtUsername.Text, txtPassword.Password);
                if (user != null)
                {
                    ID = user.UserID;
                    openForm = true;
                }
                else
                {
                    MessageBox.Show("Username or Password not correct", "Login", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            if (openForm)
            {
                //Show the diary selector
                con.Show_Diary(ID);
                this.Close();
            }
        }
    }
}
