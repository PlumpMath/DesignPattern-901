using System;

namespace NameFactory
{
    /// <summary>
    /// Summary description for LastFirst.
    /// </summary>
    public class LastFirst : Namer
    {
        public LastFirst(string name)
        {
            var i = name.IndexOf(",", StringComparison.Ordinal);
            if (i > 0)
            {
                LastName = name.Substring(0, i);
                FirstName = name.Substring(i + 1).Trim();
            }
            else
            {
                LastName = name;
                FirstName = "";
            }
        }
    }
}