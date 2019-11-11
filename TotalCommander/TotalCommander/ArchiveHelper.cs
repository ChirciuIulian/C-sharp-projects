using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using Ionic.Zip;
using System.IO.Packaging;
using System.Windows.Controls;
using System.Windows;

namespace TotalCommander
{
    class ArchiveHelper
    {
        MainWindow treeUI = new MainWindow();
        public string selectedPath;
        public object treeview;

        public ArchiveHelper(object treeview, string selectedPath)
        {
            this.selectedPath = selectedPath;
            this.treeview = treeview;
        }

        public void archiveLocation(TreeViewItem selectedNode, TreeViewItem parentNode)
        {
            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AlternateEncoding = new UTF8Encoding();
                    zip.AddDirectory(selectedPath);
                    zip.Comment = "The zip was created at " + DateTime.Now.ToString("G");
                    zip.Save(selectedPath + ".zip");
                    parentNode.Items.Add(treeUI.createTreeItem(selectedNode.Tag + ".zip"));
                }
            }
            catch
            {
                MessageBox.Show("Cannot archive this folder");
            }

        }

        public void unarchiveLocation(TreeViewItem selectedNode, TreeViewItem parentNode)
        {
            if (selectedPath.Contains(".zip"))
            {
                string targetPath = Directory.GetParent(selectedPath).FullName;

                using (ZipFile zf = new ZipFile(selectedPath))
                {
                    zf.ExtractAll(targetPath, ExtractExistingFileAction.OverwriteSilently);
                    DirectoryInfo dir = new DirectoryInfo(selectedPath);
                    parentNode.Items.Add(treeUI.createTreeItem(selectedNode.Tag));
                    MessageBox.Show("The zip file has been extracted");
                }
            }
            else
                MessageBox.Show("You cannot unzip this file");
        }
    }
}
