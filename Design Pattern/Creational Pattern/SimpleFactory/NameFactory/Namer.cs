namespace NameFactory
{
    /// <summary>
    /// Summary description for Namer.
    /// </summary>
    //Base class for getting split names
    public class Namer
    {
        //parts stored here
        protected string FirstName;
        protected string LastName;

        //return first name
        public string GetFirstName()
        {
            return FirstName;
        }

        //return last name
        public string GetLastName()
        {
            return LastName;
        }
    }
}