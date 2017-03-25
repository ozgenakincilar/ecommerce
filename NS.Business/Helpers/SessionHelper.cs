using System.Web;

namespace NS.Business.Helpers
{
    public static class SessionHelper
    {
        public static T GetSessionAsObject<T>(string key)
        {
            return (T)HttpContext.Current.Session[key];
        }

        public static void SetSessionObject(object data, string key)
        {
            HttpContext.Current.Session[key] = data;
        }
    }
}
