using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace farManager
{
    class Program
    {
        static int CONSOLE_SIZE = 26;
        static void ShowDirectoryInfo(DirectoryInfo directory, int cursor, int first)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.CursorVisible = false;
            FileSystemInfo[] fs = directory.GetFileSystemInfos();
            int index = 0;
            foreach (FileSystemInfo f in fs)
            {
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (f.GetType() == typeof(DirectoryInfo))
                {
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                if (index >= first && index <= first + CONSOLE_SIZE)
                {
                    Console.WriteLine(f.Name);
                    index++;
                }
            }
        }
        public static void DrawLAT()
        {

            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Myrz\Desktop");
            FileSystemInfo[] items = dir.GetFileSystemInfos();
            for (int i = 0; i < items.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(90, i);
                Console.WriteLine(items[i].LastAccessTime);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\Users\Myrz\Desktop");
            int first = 0;
            int cursor = 0;

            ShowDirectoryInfo(directory, cursor, first);
            int n = directory.GetFileSystemInfos().Length;

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor < 0)
                    {
                        cursor = n - 1;
                        first = cursor - CONSOLE_SIZE;
                    }
                    if (cursor < first)
                    {
                        first--;
                    }
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                    {
                        cursor = 0;
                        first = 0;
                    }
                    if (cursor > first + CONSOLE_SIZE)
                    {
                        first++;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    if (directory.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directory = (DirectoryInfo)directory.GetFileSystemInfos()[cursor];
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                        first = 0;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directory.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }

                }
                if (key.Key == ConsoleKey.Escape)
                {
                    if (directory.Parent != null)
                    {
                        directory = directory.Parent;
                        cursor = 0;
                        n = directory.GetFileSystemInfos().Length;
                        first = 0;
                    }
                    else
                        break;
                }
                ShowDirectoryInfo(directory, cursor, first);
                DrawLAT();
            }
        }
    }

}