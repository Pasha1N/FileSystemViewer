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
        private Folder myComputer;

        public Down(IList<string> paths, IList<_Directory> folders, Current current, Folder myComputer)
        {
            this.paths = paths;
            this.current = current;
            this.folders = folders;
            this.myComputer = myComputer;
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

                myComputer.SetCoordinatesCurrentDirectory();
            }
        }
    }
}