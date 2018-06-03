using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystemViewer
{
    static internal class WindowSize
    {
        static private int windowHeight = 0;
        static private int minimumCoordinate = 0;
        static private bool initialize = true;

        static public int Minimum
        {
            get { return minimumCoordinate; }
            set { minimumCoordinate = value; }
        }

        static public int MaximumHeight
        {
            get { return windowHeight; }
            set { windowHeight = value; }
        }

        static public void Initialization()
        {
            if (initialize)
            {
                WindowSize.MaximumHeight = Console.WindowHeight;
                initialize = false;
            }
        }
    }
}