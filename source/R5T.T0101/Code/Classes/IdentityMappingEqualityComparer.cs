using System;
using System.Collections.Generic;


namespace R5T.T0101
{
    public class IdentityMappingEqualityComparer<T> : IEqualityComparer<T>
        where T : IIdentityMapping
    {
        #region Static

        public static IdentityMappingEqualityComparer<T> Instance { get; } = new();

        #endregion


        public bool Equals(T x, T y)
        {
            var output = true
                && x.ExternalIdentity == y.ExternalIdentity
                && x.LocalIdentity == y.LocalIdentity
                ;

            return output;
        }

        public int GetHashCode(T obj)
        {
            var output = HashCode.Combine(
                obj.LocalIdentity,
                obj.ExternalIdentity);

            return output;
        }
    }
}
