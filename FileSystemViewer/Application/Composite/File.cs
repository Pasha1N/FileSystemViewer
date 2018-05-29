using System;
using System.IO;

namespace FileSystemViewer.Application.Composite
{
    internal class _File : _Directory
    {
        public _File(string path)
        {
            Way = path;
            FileInfo file = new FileInfo(path);
            Name = file.Name;
        }

        public override void Coordinator()
        {
            Coordinate = Counter.Count;
            Counter.Count++;
        }

        public override void ShowName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (Current)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }

            Console.Write(Name);
            ShowLength();
            Console.ResetColor();
        }

        override public void Show()
        {
            ShowName();
        }

        public void ShowLength()
        {
            FileInfo file = new FileInfo(Way);
            long length = file.Length;
            double b = length;
            double deliteli = 1024;
            int count = 0;

            while (b >= deliteli)
            {
                b /= deliteli;
                count++;
            }

            if (count == 0)
            {
                Console.WriteLine(" ( " + b + "B ) ");
            }
            else if (count == 1)
            {
                Console.WriteLine(" ( " + Math.Round(b, 2) + "Kb ) ");
            }
            else if (count == 2)
            {
                Console.WriteLine(" ( " + Math.Round(b, 2) + "Mb )");
            }
            else if (count == 3)
            {
                Console.WriteLine(" ( " + Math.Round(b, 2) + "Gb )");
            }
        }
    }
}