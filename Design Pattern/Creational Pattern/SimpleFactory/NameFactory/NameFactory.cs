using System;

namespace NameFactory
{
    /// <summary>
    /// Summary description for NameFactory.
    /// </summary>
    public class NameFactory
    {
        public NameFactory()
        {
        }

        public Namer GetName(string name)
        {
            var i = name.IndexOf(",", StringComparison.Ordinal);
            if (i > 0)
            {
                return new LastFirst(name);
            }
            return new FirstFirst(name);
        }
    }
}