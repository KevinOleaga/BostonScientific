using System.Globalization;

namespace BostonScientific.DAL
{
    public class tools
    {
        // Capitalize
        public string Capitalize(string text)
        {
            string res = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
            return res;
        }
    }
}
