using FileSystemViewer.Application.Composite;
using System;
using System.Collections.Generic;

namespace FileSystemViewer.Application.Command.DiskOperations
{
    internal class DownDisk : ICommand
    {
        private Current current;
        private IList<_Directory> folders;
        private IList<string> paths;
        private Folder myComputer;

        public DownDisk(IList<string> paths, IList<_Directory> folders, Current current, Folder myComputer)
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
                foreach (Folder folder in folders)
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

                foreach (Folder folder in folders)
                {
                    if (folder.Way == paths[current.Index])
                    {
                        folder.Current = true;
                    }
                }

               // myComputer.SetCoordinatesCurrentDirectory();
            }
        }
    }
}