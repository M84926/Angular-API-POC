namespace AngularPOC.Common
{
    public static class SortingHelper
    {
        public static string GetSortableString(string orderBy)
        {
            return orderBy.Replace("=", " ").Replace(";", ",").TrimEnd(',');
        }
    }
}
