using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TotalCommander
{
    class CompareHelper
    {
        private TreeViewItem firstStructure;
        private TreeViewItem secondStructure;
        MainWindow main = new MainWindow();


        public CompareHelper(TreeViewItem firstStructure, TreeViewItem secondStructure)
        {
            this.firstStructure = firstStructure;
            this.secondStructure = secondStructure;
        }

        public void hello(Window3 compare)
        {
            string[] File1Lines = File.ReadAllLines(main.getPath(firstStructure));
            string[] File2Lines = File.ReadAllLines(main.getPath(secondStructure));
            int maxLines;

            if (File1Lines.Length > File2Lines.Length)
                maxLines = File1Lines.Length;
            else
                maxLines = File2Lines.Length;

            for (int lineNo = 0; lineNo < maxLines; lineNo++)
            {
                if (File1Lines[lineNo].Equals(File2Lines[lineNo]))
                {
                    compare.CompareLines.Children.Add(blackText(File1Lines[lineNo]));
                }
                else
                {
                    compare.CompareLines.Children.Add(redText(File1Lines[lineNo]));
                }
            }
            compare.ShowDialog();
        }

        private TextBlock redText(string text)
        {
            TextBlock redTextLine = new TextBlock();
            redTextLine.Foreground = Brushes.Red;
            redTextLine.Text = text;

            return redTextLine;
        }

        private TextBlock blackText(string text)
        {
            TextBlock blackTextLine = new TextBlock();
            blackTextLine.Foreground = Brushes.Black;
            blackTextLine.Text = text;

            return blackTextLine;
        }
    }
}
