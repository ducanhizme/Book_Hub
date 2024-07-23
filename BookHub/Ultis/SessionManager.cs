using System.Web;

namespace BookHub.Ultis
{
    public class SessionManager
    {
        public static void SetSessionValue(string key, object value)
        {
            HttpContext.Current.Session[key] = value;
        }

        public static object GetSessionValue(string key)
        {
            return HttpContext.Current.Session[key];
        }
    }
}