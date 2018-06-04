using System;
using System.Collections.Generic;
using FileSystemViewer.Application.Composite;

namespace FileSystemViewer.Application.Command
{
    internal class Down : ICommand
    {
        private Current current;
        private IList<_Directory> folders;
        private IList<string> paths;

        public Down(IList<string> paths, IList<_Directory> folders, Current current)
        {
            this.paths = paths;
            this.current = current;
            this.folders = folders;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.DownArrow)
            {
                foreach (_Directory folder in folders)
                {
                    if (folder.Way == paths[current.Index])
                    {
                        folder.Current = false;
                    }
                }

                //потому что первый элемент под индексом нуль
                if (current.Index < paths.Count - 1)
                {
                    current.Index++;
                }

                foreach (_Directory folder in folders)
                {
                    if (folder.Way == paths[current.Index])
                    {
                        folder.Current = true;

                        foreach (_Directory folder1 in folders)
                        {
                            folder1.CoordinateCurrentDyrectory = folder.Coordinate;
                        }
                    }
                }
            }
        }
    }
}