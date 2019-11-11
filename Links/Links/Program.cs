using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Links
{
    class Program
    {

        static void Main(string[] args)
        {

            string input = null;
            Console.WriteLine("Write the path to the folder: ");
            input = Console.ReadLine();

            Application app = new Application();

            int count_doc = 0;
            try
            {
                string[] folder = Directory.GetFiles(input,
                           "*.docx",
                           SearchOption.AllDirectories);


                List<string> list = new List<string>(folder);
                list.RemoveAll(x => x.Contains("\\~$"));
                folder = null;

                foreach (string file in list)
                {
                    Console.WriteLine(" -'{0}'has the following old links: ", file);
                    count_doc++;

                    Document document = app.Documents.Open(file, Visible: true);

                    int count_word = document.Hyperlinks.Count;
                    for (int i = 1; i <= count_word; i++)
                    {

                        string text = document.Hyperlinks[i].TextToDisplay;


                        try
                        {
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(document.Hyperlinks[i].Address);
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            if (response.StatusCode == HttpStatusCode.OK)
                            {
                                Stream receiveStream = response.GetResponseStream();
                                StreamReader readStream = null;

                                if (response.CharacterSet == null)
                                {
                                    readStream = new StreamReader(receiveStream);
                                }
                                else
                                {
                                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                                }

                                string data = readStream.ReadToEnd();
                            }
                        }
                        catch
                        {

                            Console.WriteLine("------------" + text);
                        }


                    }
                    try
                    {
                        document.Close(); ;
                        Console.WriteLine("Document closed succesfully" + " \n");
                    }
                    catch
                    {
                        Console.WriteLine("Document could not be closed" + "\n");
                    }
                }
                app.Quit();
                Console.WriteLine("\n" + "Inside the folder there are {0} WORD files " + "\n", count_doc);

            }

            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
                app.Quit();
            }
        }


    }
}