using System;

namespace NameFactory
{
    /// <summary>
    /// Summary description for FirstFirst.
    /// </summary>
    public class FirstFirst : Namer
    {
        public FirstFirst(string name)
        {
            var i = name.IndexOf(" ", StringComparison.Ordinal);
            if (i > 0)
            {
                FirstName = name.Substring(0, i).Trim();
                LastName = name.Substring(i + 1).Trim();
            }
            else
            {
                LastName = name;
                FirstName = "";
            }
        }
    }
}