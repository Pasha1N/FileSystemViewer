using System;

namespace FileSystemViewer
{
    static internal class WindowSize
    {
        static private int consoleWindowHeight = Console.WindowHeight;
        static private bool initialize = true;
        static private int minimumCoordinate = 1;
        static private int windowHeight = 0;

        static public int MaximumHeight
        {
            get { return windowHeight; }
            set { windowHeight = value; }
        }

        static public int Minimum
        {
            get { return minimumCoordinate; }
            set { minimumCoordinate = value; }
        }

        static public void Initialization()
        {
            if (initialize)
            {
                WindowSize.MaximumHeight = Console.WindowHeight-1;
                initialize = false;
            }
        }
    }
}