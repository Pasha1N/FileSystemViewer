using System;
using FileSystemViewer.Application.Composite;

namespace FileSystemViewer.Application.Command
{
    internal class Left : ICommand
    {
        private Folder mainFolder;
        private Folder myComputer;
        private ToWork toWork;
        private int minimumDirectoryHeight;
        private int maximumDirectoryHeight;

        public Left(Folder mainFolder, Folder myComputer, ToWork toWork,int minimumDirectoryHeight,int maximumDirectoryHeight)
        {
            this.maximumDirectoryHeight = maximumDirectoryHeight;
            this.minimumDirectoryHeight = minimumDirectoryHeight;
            this.toWork = toWork;
            this.mainFolder = mainFolder;
            this.myComputer = myComputer;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.LeftArrow)
            {
                WindowSize.MaximumHeight = maximumDirectoryHeight;
                WindowSize.Minimum = minimumDirectoryHeight;
                mainFolder.Childrens.Clear();
                toWork.Working = false;
                Counter.DefaultValue();
                myComputer.Coordinator();
            }
        }
    }
}