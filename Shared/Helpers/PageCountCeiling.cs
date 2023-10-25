namespace Shared.Helpers
{
    public static class PageCountCeiling
    {
        public static int Ceiling(int ItemCount,int pageSize)
        {
            return (int)Math.Ceiling((decimal)ItemCount/pageSize);
        }
    }
}