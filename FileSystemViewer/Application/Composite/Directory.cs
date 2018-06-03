using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileSystemViewer.Application.Composite
{
    internal abstract class _Directory
    {
        private bool current;
        private bool head;
        private int indentationsLength;
        private string name;
        private string path;
        private bool thisDisk;
        private int y;
        static private int coordinateCurrentDyrectory = -1;

        public int Coordinate
        {
            get { return y; }
            set { y = value; }
        }

        public int CoordinateCurrentDyrectory
        {
            get { return coordinateCurrentDyrectory; }
            set { coordinateCurrentDyrectory = value; }
        }

        public bool Current
        {
            get { return current; }
            set
            {
                if (value)
                {
                    coordinateCurrentDyrectory = this.Coordinate;
                }
                current = value;
            }
        }

        public bool Head
        {
            get { return head; }
            set { head = value; }
        }

        public int IndentationsLength
        {
            get { return indentationsLength; }
            set { indentationsLength = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool ThisDisk
        {
            get { return thisDisk; }
            set { thisDisk = value; }
        }

        public string Way
        {
            get { return path; }
            set { path = value; }
        }

        public abstract void Coordinator();

        abstract public void Show();

        abstract public void ShowName();
    }
}