namespace FileSystemViewer
{
    internal class ToWork
    {
        private bool toWork;

        public ToWork(bool toWork)
        {
            this.toWork = toWork;
        }

        public bool Working
        {
            get { return toWork; }
            set { toWork = value; }
        }
    }
}