using System;

namespace FileSystemViewer.Application.Command
{
    interface ICommand
    {
        void Executive(ConsoleKeyInfo key);
    }
}