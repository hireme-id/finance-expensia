namespace Finance.Expensia.Shared.Helpers
{
    public static class GeneralHelper
    {
        /// <summary>
        /// Clone object into another object with different variable
        /// </summary>
        public static T? Clone<T>(T obj) => JsonHelper.DeserializeObject<T>(JsonHelper.SerializeObject(obj));
    }
}
