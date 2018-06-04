using System;

namespace FileSystemViewer.Application.Command
{
    internal interface ICommand
    {
        void Executive(ConsoleKeyInfo key);
    }
}