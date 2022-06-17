namespace Domain
{
    using System;

    public class Tenant : Identifier, IEquatable<Tenant>, IComparable<Tenant>
    {
        public int CompareTo(Tenant other)
        {
            throw new NotImplementedException();
        }

        public bool Equals(Tenant other)
        {
            throw new NotImplementedException();
        }
    }
}
