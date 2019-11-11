using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow treeUI = new MainWindow();
        public string selectedPath;
        public object treeview;

        public Window1(object firstStructure, string selectedPath)
        {
            this.treeview = firstStructure;
            this.selectedPath = selectedPath;
            InitializeComponent();
        }
/* --------------- METHODS ---------- */

        //Gets folder path and adds a name extension to it
        public string createdFolderPath()
        {
            string finalPath = this.selectedPath + "\\" + folder_name.Text;
            return finalPath;
        }

        //Search for folder
        public bool isItemFound(string searchedFolder)
        {
           if (Directory.Exists(createdFolderPath()))
           {
               return true;
           }
         return false;
        }

        /* --------------- METHODS ---------- */

        /* -------------- BUTTONS -------------*/

        private void Ok_btn(object sender, RoutedEventArgs e)
        {
            string stringPath = createdFolderPath();

            if (isItemFound(folder_name.Text))
            {
                MessageBox.Show("Folder already exists");
            }
            else
            {
                var parent = treeview as TreeViewItem;
                Directory.CreateDirectory(stringPath);
                DirectoryInfo dir = new DirectoryInfo(stringPath);
                parent.Items.Add(treeUI.createTreeItem(folder_name.Text));
                MessageBox.Show("The folder has beeen created");
            }
        }

        private void Cancel_btn(object sender, RoutedEventArgs e)
        {

        }

        /* -------------- BUTTONS -------------*/
    }
}
