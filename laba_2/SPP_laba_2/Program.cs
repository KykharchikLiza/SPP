using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace laba_2
{
    delegate void TaskDelegate(string from, string to);

    class Program
    {

        private static ThreadPool threadPool;
        private static string source_directory;
        private static string final_directory;

        static void Main(string[] args)
        {
            Console.WriteLine("Write source_directory");
            source_directory = Console.ReadLine();

            Console.WriteLine("Write final_directory");
            final_directory = Console.ReadLine();


            if (Directory.Exists(source_directory) && Directory.Exists(final_directory))
            {
                threadPool = new ThreadPool(7);
                List<string> list = new List<string>();
                recursion(list, source_directory);


                foreach (string file in list)
                {
                    threadPool.EnqueueTask(copyFile, new CopyFileInfo(file, final_directory));
                }
            }
            else
            {
                Console.WriteLine("Directory does not exist");
            }

            while (threadPool.getTasks() != 0)
            {

            }
            Console.WriteLine($"Сopied files : {threadPool.count}");


            Console.ReadLine();
        }

        public static void recursion(List<string> list, string directory)
        {
            string[] files = Directory.GetFiles(directory); //получаем список файлов в каталоге
            foreach(string file in files)
            {
                list.Add(file);
            }
            string[] dirs = Directory.GetDirectories(directory);//получает список каталогов в каталоге
            foreach(string dir in dirs)
            {
                recursion(list, dir);
            }
        }

        public static void copyFile(string from, string to)
        {
            File.Copy(from, to, true);
            //   Console.WriteLine(Thread.CurrentThread.Name); 
            Thread.Sleep(1);
        }
    }
}
