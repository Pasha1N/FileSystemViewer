namespace FileSystemViewer.Application.Composite
{
    internal class Current
    {
        private int current = 0;

        public int Index
        {
            get { return current; }
            set { current = value; }
        }
    }
}