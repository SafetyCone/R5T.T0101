using System;
using System.Collections.Generic;

using R5T.T0060;
using R5T.T0101;


namespace System
{
    public static class IPredicateExtensions
    {
        public static Func<T, bool> ExternalIdentityIs<T>(this IPredicate _, Guid identity)
            where T : IIdentityMapping
        {
            return mapping => mapping.ExternalIdentity == identity;
        }

        public static Func<T, bool> IdentitiesAre<T>(this IPredicate _,
            Guid localIdentity, Guid externalIdentity)
            where T : IIdentityMapping
        {
            return mapping => mapping.LocalIdentity == localIdentity && mapping.ExternalIdentity == externalIdentity;
        }

        public static Func<T, bool> LocalIdentityIs<T>(this IPredicate _, Guid identity)
            where T : IIdentityMapping
        {
            return mapping => mapping.LocalIdentity == identity;
        }

        public static Func<T, bool> LocalIdentityIs<T>(this IPredicate _,
            IEnumerable<Guid> identities,
            Dictionary<Guid, bool> results)
            where T : IIdentityMapping
        {
            var uniqueIdentitiesHash = new HashSet<Guid>(identities);

            bool Output(T mapping)
            {
                var identity = mapping.LocalIdentity;

                var contains = uniqueIdentitiesHash.Contains(identity);
                if (contains)
                {
                    results.Add(identity, true);
                }
                else
                {
                    results.Add(identity, false);
                }

                return contains;
            }

            return Output;
        }
    }
}