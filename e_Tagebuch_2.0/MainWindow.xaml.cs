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
            e_Tagebuch_Context con = new e_Tagebuch_Context();
            if (!con.Users.Any())
            {
                con.Users.Add(new User()
                {
                    Username = "User",
                    Password = "Password"
                });
                con.SaveChanges();
            }

            //Create all possible types
            string[] Types = new string[]{ "Work", "Family", "Holidays", "Birthday", "School"};
            foreach (string typeName in Types)
            {
                if (!con.Types.Any(t => t.Name == typeName))
                {
                    con.Types.Add(new Type()
                    {
                        Name = typeName
                    });
                }
            }
            con.SaveChanges();
        }

        private void bntLogin_Click(object sender, RoutedEventArgs e)
        {
            //Check if the user logi
            controlling con = new controlling();
            if (con.Check_Credential(txtUsername.Text,txtPW.Text))
            {
                con.Show_Diary(txtUsername.Text);
                this.Hide();
            } 
            else
            {
                MessageBox.Show("Username or Password not correct","Login", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
