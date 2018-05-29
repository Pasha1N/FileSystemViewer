﻿using System;
using FileSystemViewer.Application.Composite;

namespace FileSystemViewer.Application.Command
{
    internal class Left : ICommand
    {
        private Folder mainFolder;
        private Folder myComputer;
        private ToWork toWork;

        public Left(Folder mainFolder, Folder myComputer, ToWork toWork)
        {
            this.toWork = toWork;
            this.mainFolder = mainFolder;
            this.myComputer = myComputer;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                Counter.Count -= mainFolder.Childrens.Count;
                mainFolder.Childrens.Clear();
                toWork.Working = false;
            }
        }
    }
}