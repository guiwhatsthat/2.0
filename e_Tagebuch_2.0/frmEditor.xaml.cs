﻿using Microsoft.Win32;
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
                dpDatepicker.SelectedDate = DateTime.Now;
            } else
            {
                dpDatepicker.SelectedDate = entry.Date;
            }
                
        }

        private void BntSave_Click(object sender, RoutedEventArgs e)
        {
            //Saves current data
            controlling con = new controlling();
            if (txtName.Text == null || dpDatepicker.SelectedDate == null|| txtMain.Text == null || lblPicPath.Content == null)
            {
                MessageBox.Show("None of the values can be empty", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            } else
            {
                con.Save_Entry(EntryID, txtName.Text, dpDatepicker.SelectedDate.Value, txtMain.Text, lblPicPath.Content.ToString());
            }            
        }

        private void BntClose_Click(object sender, RoutedEventArgs e)
        {
            //Gets the user back to the search window without saving the current editing diary
            controlling con = new controlling();
            var diary = con.Get_DiaryFromEntry(EntryID);
            frmSearchWindow searchWindow = new frmSearchWindow(diary.DiaryID);
            searchWindow.Show();
            this.Close();
        }

        private void BntChoose_Click(object sender, RoutedEventArgs e)
        {
            //Opens the GUI where the user can select the types
            frmTypeSelector typeSelector = new frmTypeSelector(EntryID);
            typeSelector.Show();
        }

        private void BntChoosePic_Click(object sender, RoutedEventArgs e)
        {
            //The openfile dialog for the picture lable. Will only store the filepathname
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                lblPicPath.Content = openFileDialog.FileName;
            }
        }
    }
}
