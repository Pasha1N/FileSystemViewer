﻿using System;
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
                Counter.Count++;
                directory.Coordinate = Counter.Count;
                directory.Coordinator();
            }
        }

        override public void SetCoordinatesCurrentDirectory()
        {
            //int currentCoordinates = 1;

            foreach (_Directory child in Children)
            {
                if (child.Current)
                {
                    CoordinateCurrentDyrectory = child.Coordinate;

                }
            }

            foreach (_Directory child in Children)
            {
                //child.CoordinateCurrentDyrectory = currentCoordinates;
                child.CoordinateCurrentDyrectory = CoordinateCurrentDyrectory;
                child.SetCoordinatesCurrentDirectory();
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

            //    Console.WriteLine(Name);
            //   Console.ResetColor();
            Console.Write(Name);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Coordinate);
            Console.ResetColor();
        }

        override public void Show()
        {
            for (int i = 0; i < Children.Count; i++)
            {
                WindowSize.Initialization();
                if (!Children[i].ThisDisk)
                {
                    if (Children[i].CoordinateCurrentDyrectory >= WindowSize.MaximumHeight)
                    {
                        WindowSize.MaximumHeight++;
                        WindowSize.Minimum++;
                    }

                    if (Children[i].CoordinateCurrentDyrectory <= WindowSize.Minimum)
                    {
                        WindowSize.MaximumHeight--;
                        WindowSize.Minimum--;
                    }
                }

                if (Children[i].Coordinate >= WindowSize.Minimum && Children[i].Coordinate < WindowSize.MaximumHeight)
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
                        if (i < Children.Count - 1 && Children[i] is Folder && Children[i + 1] is _File)
                        {
                            Console.Write((char)0x2514);
                        }
                        else if (Children[i] is Folder)
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
                    Children[i].ShowName();
                }
                Children[i].Show();
            }
        }

        public void AddChildren(_Directory directory)
        {
            Children.Add(directory);
        }
    }
}

 //for (int i = 0; i<Children.Count; i++)
 //           {
 //               WindowSize.Initialization();

 //               if (Children[i].Coordinate >= WindowSize.Minimum && Children[i].Coordinate<WindowSize.MaximumHeight)
 //               {
 //                   if (Children[i].CoordinateCurrentDyrectory > WindowSize.MaximumHeight - 1)
 //                   {
 //                       WindowSize.MaximumHeight++;
 //                       WindowSize.Minimum++;
 //                   }

 //                   if (Children[i].CoordinateCurrentDyrectory <= WindowSize.Minimum)
 //                   {
 //                       WindowSize.MaximumHeight--;
 //                       WindowSize.Minimum--;
 //                   }

 //                   int @switch = 0;
 //                   for (int j = 0; j<Children[i].IndentationsLength; j++)
 //                   {
 //                       if (@switch == 0)
 //                       {
 //                           Console.Write(' ');
 //                           @switch++;
 //                       }
 //                       else
 //                       {
 //                           if (!Children[i].ThisDisk)
 //                           {
 //                               Console.Write((char)0x2502);
 //                           }
 //                           @switch--;
 //                       }
 //                   }

 //                   if (i<Children.Count - 1)
 //                   {
 //                       if (i<Children.Count - 1 && Children[i] is Folder && Children[i + 1] is _File)
 //                       {
 //                           Console.Write((char)0x2514);
 //                       }
 //                       else if (Children[i] is Folder)
 //                       {
 //                           Console.Write((char)0x251C);
 //                       }
 //                       else
 //                       {
 //                           Console.Write((char)0x2502);
 //                           Console.Write("  ");
 //                       }
 //                   }
 //                   else
 //                   {
 //                       if (Children[i] is Folder)
 //                       {
 //                           Console.Write((char)0x2514);
 //                       }
 //                       else
 //                       {
 //                           Console.Write((char)0x2502);
 //                           Console.Write("  ");
 //                       }
 //                   }
 //                   Children[i].ShowName();
 //               }
 //               Children[i].Show();
 //           }