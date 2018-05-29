using FileSystemViewer.Application.Composite;
using System;

namespace FileSystemViewer.Application
{
    internal static class ShowComposite
    {
        public static void show(Folder folder)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            folder.Show();
        }
    }
}