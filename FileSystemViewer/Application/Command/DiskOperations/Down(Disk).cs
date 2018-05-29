﻿using FileSystemViewer.Application.Composite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemViewer.Application.Command.DiskOperations
{
    class DownDisk : ICommand
    {
        private Current current;
        private IList<string> paths;
        private IList<_Directory> folders;

        public DownDisk(IList<string> paths, IList<_Directory> folders, Current current)
        {
            this.paths = paths;
            this.current = current;
            this.folders = folders;
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
            }
        }
    }
}