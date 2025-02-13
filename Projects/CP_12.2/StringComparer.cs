namespace Task2
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null && y == null)
                return 0;
            if (x == null)
                return -1;
            if (y == null)
                return 1;
            return x.Length.CompareTo(y.Length);
        }
    }
}
