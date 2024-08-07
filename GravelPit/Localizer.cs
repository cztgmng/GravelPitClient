using System.Globalization;
using System.Resources;

namespace GravelPit
{
    public static class Localizer
    {
        private static ResourceManager rm = new ResourceManager("GravelPit.Resources", typeof(Localizer).Assembly);

        public static string GetTranslation(string key)
        {
            return rm.GetString(key, CultureInfo.CurrentCulture);
        }
    }
}
