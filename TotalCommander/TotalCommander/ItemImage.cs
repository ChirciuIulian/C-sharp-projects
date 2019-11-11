using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace TotalCommander
{
    static class ItemImage
    {

        // Create Image StackPanel
        public static StackPanel CustomizeTreeViewItem(object itemObj)
        {
            // Add Icon
            // Create Stack Panel
            StackPanel stkPanel = new StackPanel();
            stkPanel.Orientation = Orientation.Horizontal;

            // Create Image
            Image img = new Image();
            if (itemObj.ToString().Contains(".zip") || itemObj.ToString().Contains(".7z"))
                img.Source = new BitmapImage(new Uri("C:/Users/IulianChirciu/source/repos/TotalCommander/TotalCommander/Pictures/zip.jpg"));
            else if (itemObj.ToString().Contains("."))
                img.Source = new BitmapImage(new Uri("C:/Users/IulianChirciu/source/repos/TotalCommander/TotalCommander/Pictures/file.jpg"));
            else
                img.Source = new BitmapImage(new Uri("C:/Users/IulianChirciu/source/repos/TotalCommander/TotalCommander/Pictures/folder.jpg"));
            img.Width = 16;
            img.Height = 16;

            // Create TextBlock
            TextBlock lbl = new TextBlock();
            lbl.Text = itemObj.ToString();

            // Add to stack
            stkPanel.Children.Add(img);
            stkPanel.Children.Add(lbl);

            return stkPanel;
        }
    }
}
