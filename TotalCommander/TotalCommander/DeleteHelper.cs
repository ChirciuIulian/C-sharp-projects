using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander
{
    class DeleteHelper
    {
        private MainWindow mainWindow = new MainWindow();
        private string selectedPath;

        public DeleteHelper(string selectedPath)
        {
            this.selectedPath = selectedPath;
        }

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


    }
}
