using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TotalCommander
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var drives = DriveInfo.GetDrives();
            foreach (var driveInfo in drives)
            {
                firstStructure.Items.Add(createTreeItem(driveInfo));
                secondStructure.Items.Add(createTreeItem(driveInfo));
            }

        }
        /* -------------- METHODS -------------*/
        #region Create Tree
        // Expands Treeview
        public void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            if (item.Items.Count == 1 && item.Items[0] is string)
            {
                item.Items.Clear();
                DirectoryInfo expandedDir = null;
                FileInfo expandedFile = null;
                if (item.Tag is DriveInfo)
                    expandedDir = (item.Tag as DriveInfo).RootDirectory;
                if (item.Tag is DirectoryInfo)
                    expandedDir = (item.Tag as DirectoryInfo);
                if (item.Tag is FileInfo)
                    expandedFile = (item.Tag as FileInfo);

                foreach (DirectoryInfo subDir in expandedDir.GetDirectories())
                  item.Items.Add(createTreeItem(subDir));
                foreach (FileInfo subFile in expandedDir.GetFiles("*.*"))
                  item.Items.Add(createTreeItem(subFile));
            }
        }
        //Creates a new Treeview Item
        public TreeViewItem createTreeItem(object fileObject)
        {
            TreeViewItem item = new TreeViewItem();
            item.Header = ItemImage.CustomizeTreeViewItem(fileObject);
            item.Tag = fileObject;
            item.Items.Add("");
            
            return item;
        }
        #endregion
        //GetPath Helper
        static TreeViewItem GetParentItem(TreeViewItem item)
        {
            for (var i = VisualTreeHelper.GetParent(item); i != null; i = VisualTreeHelper.GetParent(i))
                if (i is TreeViewItem)
                    return (TreeViewItem)i;

            return null;
        }
        //Get folder path from selected item
        public string getPath(TreeViewItem node)
        {
            var result = Convert.ToString(node.Tag);

            for (var i = GetParentItem(node); i != null; i = GetParentItem(i))
                result = i.Tag + "\\" + result;

            return result;
        }
        /* -------------- METHODS -------------*/
        /* -------------- BUTTONS -------------*/
        //Print selected item Path button (TO BE DELETED)
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem first = firstStructure.SelectedItem as TreeViewItem;
            MessageBox.Show(getPath(first));
        }
        //Create folder
        private void Create_Folder_btn(object sender, RoutedEventArgs e)
        {
            Window1 create_popup = new Window1(firstStructure.SelectedItem, getPath(firstStructure.SelectedItem as TreeViewItem));
            create_popup.ShowDialog();
        }
        private void Create_Folder_btn2(object sender, RoutedEventArgs e)
        {
            Window1 create_popup = new Window1(secondStructure.SelectedItem, getPath(secondStructure.SelectedItem as TreeViewItem));
            create_popup.ShowDialog();
        }
        //Delete folder
        private void Delete_Folder_btn(object sender, RoutedEventArgs e)
        {
            DeleteHelper delete = new DeleteHelper(getPath(firstStructure.SelectedItem as TreeViewItem));
            if (delete.deleteAlert())
            {
                MessageBox.Show("The folder has been deleted");
            }
            TreeViewItem item = firstStructure.SelectedItem as TreeViewItem;
        }
        //View Folder/File
        private void View_btn(object sender, RoutedEventArgs e)
        {
            Process.Start(getPath(firstStructure.SelectedItem as TreeViewItem));
        }
        private void View_btn2(object sender, RoutedEventArgs e)
        {
            Process.Start(getPath(secondStructure.SelectedItem as TreeViewItem));
        }
        private void Archive_Folder_menu_item(object sender, RoutedEventArgs e)
        {
            ArchiveHelper archive = new ArchiveHelper(firstStructure.SelectedItem, getPath(firstStructure.SelectedItem as TreeViewItem));
            TreeViewItem node = firstStructure.SelectedItem as TreeViewItem;
            archive.archiveLocation(node, node.Parent as TreeViewItem);
        }
        private void Unarchive_Zip_menu_item(object sender, RoutedEventArgs e)
        {
            ArchiveHelper archive = new ArchiveHelper(firstStructure.SelectedItem, getPath(firstStructure.SelectedItem as TreeViewItem));
            TreeViewItem node = firstStructure.SelectedItem as TreeViewItem;
            archive.unarchiveLocation(node, node.Parent as TreeViewItem);
        }
        private void Exit_menu_item(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }
        private void About_menu_item(object sender, RoutedEventArgs e)
        {
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.ShowDialog();
        }
        private void Compare_By_menu_item(object sender, RoutedEventArgs e)
        {
            CompareHelper compare = new CompareHelper(firstStructure.SelectedItem as TreeViewItem, secondStructure.SelectedItem as TreeViewItem);
            Window3 window = new Window3();
            compare.hello(window);
        }

        private void BtnDelete2_Click(object sender, RoutedEventArgs e)
        {
            DeleteHelper delete = new DeleteHelper(getPath(secondStructure.SelectedItem as TreeViewItem));
            if (delete.deleteAlert())
            {
                MessageBox.Show("The folder has been deleted");
            }
        }
        /* -------------- BUTTONS -------------*/
    }
}