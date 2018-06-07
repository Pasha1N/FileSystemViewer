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
        }

        public override void ShowName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (Current)
            {
                Console.BackgroundColor = ConsoleColor.White;
            }

            // Console.Write(Name);
            //  ShowLength();
            //  Console.WriteLine();
            //  Console.ResetColor();

            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Coordinate);
            Console.ResetColor();
        }

        override public void Show()
        {
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
                Console.Write(" ( " + b + "B ) ");
            }
            else if (count == 1)
            {
                Console.Write(" ( " + Math.Round(b, 2) + "Kb ) ");
            }
            else if (count == 2)
            {
                Console.Write(" ( " + Math.Round(b, 2) + "Mb )");
            }
            else if (count == 3)
            {
                Console.Write(" ( " + Math.Round(b, 2) + "Gb )");
            }
        }
    }
}