using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemViewer.Application.Composite
{
    internal class Folder : _Directory
    {
        private IList<_Directory> Children = new List<_Directory>();

        public Folder(string path)
        {
            Way = path;
            DirectoryInfo folder = new DirectoryInfo(path);
            Name = folder.Name;
        }

        public IList<_Directory> Childrens
        {
            get { return Children; }
        }

        public override void Coordinator()
        {
            foreach (_Directory directory in Children)
            {
                directory.Coordinate = Counter.Count;
                Counter.Count++;
                directory.Coordinator();
            }
        }

        public override void ShowName()
        {
            Console.ForegroundColor = ThisDisk ? ConsoleColor.Green : Console.ForegroundColor = ConsoleColor.Yellow; 

            if (Current)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray; 
            }

            if (Head)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            // Console.WriteLine(Name);
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(Coordinate); 
            Console.ResetColor();
        }

        override public void Show()
        {
            int windowHeight = Console.WindowHeight;
            ShowName();

            for (int i = 0; i < Children.Count; i++)
            {
                int y = Console.CursorTop;
                if (y < (windowHeight - 1))
                {
                    int @switch = 0;
                    for (int j = 0; j < Children[i].IndentationsLength; j++)
                    {
                        if (@switch == 0)
                        {
                            Console.Write(' ');
                            @switch++;
                        }
                        else
                        {
                            if (!Children[i].ThisDisk)
                            {
                                Console.Write((char)0x2502);
                            }
                            @switch--;
                        }
                    }

                    if (i < Children.Count - 1)
                    {
                        if (Children[i] is Folder)
                        {
                            Console.Write((char)0x251C);
                        }
                        else
                        {
                            Console.Write((char)0x2502);
                            Console.Write("  ");
                        }
                    }
                    else
                    {
                        if (Children[i] is Folder)
                        {
                            Console.Write((char)0x2514);
                        }
                        else
                        {
                            Console.Write((char)0x2502);
                            Console.Write("  ");
                        }
                    }
                    Children[i].Show();
                }
            }
        }

        public void AddChildren(_Directory directory)
        {
            Children.Add(directory);
        }
    }
}