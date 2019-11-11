using System;
using System.Collections.Generic;
using System.IO;
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

namespace TotalCommander
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public string selectedPath;

        public Window2()
        {
            InitializeComponent();
        }

        private void Yes_btn(object sender, RoutedEventArgs e)
        {
            DirectoryInfo path = new DirectoryInfo(selectedPath);

            foreach (FileInfo file in path.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in path.GetDirectories())
            {
                dir.Delete(true);
            }
            Directory.Delete(selectedPath);
            MessageBox.Show("The folder and its contents has been deleted");
        }
    }
}
