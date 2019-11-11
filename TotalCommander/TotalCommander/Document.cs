using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace TotalCommander
{
    class Document
    {
        private string selectedPath { get; set; }
        public object treeview { get; set; }
        private TreeViewItem firstStructure { get; set; }
        private TreeViewItem secondStructure { get; set; }

        public bool deleteAlert()
        {
            if (!isFolderEmpty(selectedPath))
            {
                Window2 deletePopup = new Window2();
                deletePopup.selectedPath = this.selectedPath;
                deletePopup.ShowDialog();
            }
            else
            {
                Directory.Delete(selectedPath);
                return true;
            }
            return false;
        }


        private bool isFolderEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
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
