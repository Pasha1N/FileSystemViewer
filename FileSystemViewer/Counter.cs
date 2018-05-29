namespace FileSystemViewer
{
    static internal class Counter
    {
        static private int count = 0;

        static public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}