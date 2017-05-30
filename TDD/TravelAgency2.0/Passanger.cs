namespace TravelAgency2._0
{
    public class Passanger
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static bool operator ==(Passanger a, Passanger b)
        {
            if (ReferenceEquals(a, null))
            {
                return ReferenceEquals(b, null);
            }

            if (ReferenceEquals(b, null))
            {
                return ReferenceEquals(a, null);
            }

            if (a.FirstName == b.FirstName && a.LastName == b.LastName)
            {
                return a.Equals(b);
            } else
            {
                return false;
            }
        }

        public static bool operator !=(Passanger a, Passanger b)
        {
            if (a == b)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }

    
}