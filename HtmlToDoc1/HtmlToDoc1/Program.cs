using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace HtmlToDoc1
{
    class Program
    {

        private static Application word;
        private static Document document;

        static void Main(string[] args)
        {

            Console.WriteLine("Input the folder path: -");
            string input = Console.ReadLine();
            string[] folder = Directory.GetFiles(input,
                       "*.html",
                       SearchOption.AllDirectories);


            List<string> list = new List<string>(folder);
            folder = null;

            foreach (string file in list)
            {
                FileInfo SrcFile = new FileInfo(file);
                FileInfo DestFile = new FileInfo(file + "convert.doc");
                if (SrcFile.Exists == false)
                {
                    throw new Exception(file + " doesn't exist.");
                }

                word = new Application();
                document = new Document();
                try
                {
                    document = word.Documents.Add();
                    word.Visible = false;

                    document = word.Documents.Open(SrcFile.FullName);

                    document.Activate();
                    //embed inline images in the document
                    foreach (InlineShape image in document.InlineShapes)
                    {
                        if (image.LinkFormat != null)
                        {
                            try
                            {
                                image.LinkFormat.SavePictureWithDocument = true;
                                image.LinkFormat.BreakLink();
                            }
                            catch (Exception ex) { /* nothing */ }
                        }
                    }

                    document.ActiveWindow.View.Type = WdViewType.wdPrintView;

                    document.SaveAs(DestFile.FullName, WdSaveFormat.wdFormatDocument);

                    document.Close(false);
                    word.Quit();
                }
                catch (Exception ex)
                {
                    try
                    {
                        document.Close(false);
                        word.Quit();
                    }
                    catch (Exception ex2) {/* nothing */}
                    throw ex;
                }
            }
        }
    }
}
