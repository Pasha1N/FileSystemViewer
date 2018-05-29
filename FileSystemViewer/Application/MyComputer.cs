using System;
using System.Collections.Generic;
using System.IO;
using FileSystemViewer.Application.Composite;
using FileSystemViewer.Application.Command;
using FileSystemViewer.Application.Command.DiskOperations;

namespace FileSystemViewer.Application
{
    internal class MyComputer
    {
        private ICollection<ICommand> commands = new List<ICommand>();
        private Current current = new Current();
        private DriveInfo[] drives = DriveInfo.GetDrives();
        private List<_Directory> folders = new List<_Directory>();
        private int indentationsLength = 1;
        private Folder myComputer = new Folder("This PC");
        private List<string> paths = new List<string>();

        public MyComputer()
        {
            Initialization();
            Management();
        }

        public void Initialization()
        {
            myComputer.Head = true;

            for (int i = 0; i < drives.Length; i++)
            {
                paths.Add(drives[i].ToString());
            }
            paths.Sort();

            for (int i = 0; i < drives.Length; i++)
            {
                Folder folder = new Folder(paths[i]);
                folder.IndentationsLength = indentationsLength;
                folder.ThisDisk = true;
                folder.Coordinate = i;
                //Counter.Count = i;
                folders.Add(folder);
                myComputer.AddChildren(folder);
            }
            folders[0].Current = true;
        }

        public void Management()
        {
            ShowComposite.show(myComputer);
            ConsoleKeyInfo key;

            while (true)
            {
                DownDisk downArrow = new DownDisk(paths, folders, current);
                Up upArrow = new Up(paths, folders, current);
                Right rightArrow = new Right(folders[current.Index] as Folder, indentationsLength, myComputer);

                commands.Add(rightArrow);
                commands.Add(downArrow);
                commands.Add(upArrow);

                key = Console.ReadKey();
                folders[current.Index].Current = false;

                foreach (ICommand command in commands)
                {
                    command.Executive(key);
                }

                folders[current.Index].Current = true;
                ShowComposite.show(myComputer);
                commands.Clear();
            }
        }
    }
}