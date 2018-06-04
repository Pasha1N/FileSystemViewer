﻿using FileSystemViewer.Application.Composite;
using System;
using System.Collections.Generic;
using System.IO;

namespace FileSystemViewer.Application.Command
{
    internal class Right : ICommand
    {
        private ICollection<ICommand> commands = new List<ICommand>();
        private Current current = new Current();
        private DirectoryInfo currentDirectory;
        private int indentationLength;
        private DirectoryInfo[] directories;
        private List<string> fileSystemEntriesPaths = new List<string>();
        private FileInfo[] files;
        private IList<_Directory> folders = new List<_Directory>();
        private Folder mainFolder;
        private int minimumDirectoryHeight = WindowSize.Minimum;
        private Folder myComputer;
        private int maximumDirectoryHeight = WindowSize.MaximumHeight;

        public Right(Folder mainFolder, int indentationLength, Folder myComputer)
        {
            this.indentationLength = indentationLength;
            this.mainFolder = mainFolder;
            this.myComputer = myComputer;
        }

        public void Executive(ConsoleKeyInfo key)
        {
            if (key.Key == ConsoleKey.RightArrow)
            {
                Initialisation();
                Counter.DefaultValue();
                myComputer.Coordinator();
                Management();
            }
        }

        public void Management()
        {
            ShowComposite.show(myComputer);
            ToWork toWork = new ToWork(true);

            while (toWork.Working)
            {
                ConsoleKeyInfo key;
                if (folders.Count > 0)
                {
                    Down downArrow = new Down(fileSystemEntriesPaths, folders, current);
                    Up upArrow = new Up(fileSystemEntriesPaths, folders, current);
                    Right rightArrow = new Right(folders[current.Index] as Folder, indentationLength + 2, myComputer);

                    commands.Add(downArrow);
                    commands.Add(upArrow);
                    commands.Add(rightArrow);
                }

                Left leftArrow = new Left(mainFolder, myComputer, toWork, minimumDirectoryHeight, maximumDirectoryHeight);
                commands.Add(leftArrow);
                key = Console.ReadKey();

                if (folders.Count > 0)
                {
                    folders[current.Index].Current = false;
                }

                foreach (ICommand command in commands)
                {
                    command.Executive(key);
                }

                if (folders.Count > 0)
                {
                    folders[current.Index].Current = true;
                }

                ShowComposite.show(myComputer);
                commands.Clear();
            }
        }

        public void Initialisation()
        {
            currentDirectory = new DirectoryInfo(mainFolder.Way);

            try
            {
                directories = currentDirectory.GetDirectories();
                files = currentDirectory.GetFiles();

                string[] directoryNames = Directory.GetDirectories(mainFolder.Way);
                string[] fileNames = Directory.GetFiles(mainFolder.Way);
                List<string> filePaths = new List<string>();
                List<string> directoryPaths = new List<string>();

                filePaths.AddRange(fileNames);
                directoryPaths.AddRange(directoryNames);

                filePaths.Sort();
                directoryPaths.Sort();

                fileSystemEntriesPaths.AddRange(directoryPaths);
                fileSystemEntriesPaths.AddRange(filePaths);
            }
            catch (UnauthorizedAccessException exception)
            {
            }

            foreach (string path in fileSystemEntriesPaths)
            {
                if (Directory.Exists(path))
                {
                    Folder folder = new Folder(path);
                    folder.IndentationsLength = indentationLength + 2;
                    folders.Add(folder);
                    mainFolder.AddChildren(folder);
                }
                else
                {
                    _File file = new _File(path);
                    file.IndentationsLength = indentationLength;
                    folders.Add(file);
                    mainFolder.AddChildren(file);
                }
            }

            try
            {
                if (currentDirectory.GetDirectories().Length > 0)
                {
                    folders[current.Index].Current = true;
                }
            }
            catch (UnauthorizedAccessException exception)
            {
            }

            foreach (_Directory folder in folders)
            {

                folder.CoordinateCurrentDyrectory = mainFolder.CoordinateCurrentDyrectory;
            }
        }
    }
}