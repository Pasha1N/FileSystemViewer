﻿using FileSystemViewer.Application.Composite;
using System;
using System.Collections.Generic;

namespace FileSystemViewer.Application.Command
{
    internal class Up : ICommand
    {
        private Current current;
        private IList<_Directory> folders;
        private IList<string> paths;

        public Up(IList<string> paths, IList<_Directory> folders, Current current)
        {
            this.paths = paths;
            this.current = current;
            this.folders = folders;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.UpArrow)
            {
                foreach (_Directory folder in folders)
                {
                    if (folder.Way == paths[current.Index])
                    {
                        folder.Current = false;
                    }
                }

                //потому что первый элемент под индексом нуль
                if (current.Index > 0)
                {
                    current.Index--;
                }

                foreach (_Directory folder in folders)
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