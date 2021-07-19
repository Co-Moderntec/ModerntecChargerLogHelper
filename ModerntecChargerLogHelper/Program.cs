using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace ModerntecChargerLogHelper
{
    class Program
    {
        static void Main(string[] args) {
            string dir = @"C:\ModerntecChargerLogHelper";
            DirectoryInfo di = new DirectoryInfo(dir);
            FileStream fs = new FileStream($@"{dir}\total_merge.log", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.Default);

            foreach (var dates_item in di.GetDirectories()) {

                Console.Write(dates_item.Name + " " + dates_item.Parent + " = ");
                DirectoryInfo di2 = new DirectoryInfo($@"{dates_item.Parent}\{dates_item.Name}\data");
                if (!di2.Exists) {
                    ZipFile.ExtractToDirectory($@"{dates_item.Parent}\{dates_item.Name}\data.zip", $@"{dates_item.Parent}\{dates_item.Name}\data");
                    Console.Write("Unzip... ");
                } else {
                    Console.Write("Skip... ");
                }

                foreach (var fileInfo in di2.GetFiles("ChargerLog.log-*")) {

                    ApplyEncoding(fileInfo.FullName);

                    foreach (var line in File.ReadAllLines(fileInfo.FullName)) {
                        sw.WriteLine(line);
                    }

                    Console.WriteLine("Writing...");
                }

            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        public static void ApplyEncoding(string textFilePath) { 
            using (var sr = new StreamReader(textFilePath)) { 
                using (var sw = new StreamWriter(textFilePath + "temp", false, Encoding.Default)) {
                    sw.WriteLine(sr.ReadToEnd());
                    sw.Close();
                }
                sr.Close(); 
            }

            File.Delete(textFilePath); 
            File.Move(textFilePath + "temp", textFilePath); 
        }

    }
}
