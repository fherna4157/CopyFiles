using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CopyFiles
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write(Directory.GetCurrentDirectory());

            string Src_FOLDER = Directory.GetCurrentDirectory();

            const string Dest_FOLDER = @"C:\Tensorflow-Bootcamp-master\Prophet\Data";

            do
            {
                try
                {
                    string[] originalFiles = Directory.GetFiles(Src_FOLDER, "*", SearchOption.AllDirectories);
                    string test = "";

                    Array.ForEach(originalFiles, (originalFileLocation) =>
                    {
                        FileInfo originalFile = new FileInfo(originalFileLocation);
                        FileInfo destFile = new FileInfo(originalFileLocation.Replace(Src_FOLDER, Dest_FOLDER));

                        if (destFile.Exists)
                        {
                            test = File.GetLastWriteTime(Src_FOLDER).ToString() + "=?" + File.GetLastWriteTime(Dest_FOLDER);
                            Console.Write(test);
                            if (originalFile.Length > destFile.Length || File.GetLastWriteTime(Src_FOLDER) != File.GetLastWriteTime(Dest_FOLDER))
                            {
                                originalFile.CopyTo(destFile.FullName, true);
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(destFile.DirectoryName);
                            originalFile.CopyTo(destFile.FullName, false);
                        }
                    });



                    //Console.Read();
                    Thread.Sleep(120000);
                }
                catch(IOException e)  {
                    Console.Write(e);
                    Thread.Sleep(120000);
                }

            } while (1 == 1);
        }
    }
}
