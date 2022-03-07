using System;
using System.Collections.Generic;

using R5T.Magyar;

using R5T.T0101;

using Instances = R5T.T0101.X001.Instances;


namespace System.Linq
{
    public static class IIdentityMappingExtensions
    {
        public static T[] FindArrayByExternalIdentity<T>(this IEnumerable<T> items, Guid identity)
            where T : IIdentityMapping
        {
            var output = items.FindArray(Instances.Predicate.ExternalIdentityIs<T>(identity));
            return output;
        }

        public static T[] FindArrayByIdentities<T>(this IEnumerable<T> items, Guid localIdentity, Guid externalIdentity)
            where T : IIdentityMapping
        {
            var output = items.FindArray(Instances.Predicate.IdentitiesAre<T>(localIdentity, externalIdentity));
            return output;
        }

        public static T[] FindArrayByLocalIdentity<T>(this IEnumerable<T> items, Guid identity)
            where T : IIdentityMapping
        {
            var output = items.FindArray(Instances.Predicate.LocalIdentityIs<T>(identity));
            return output;
        }

        public static Dictionary<Guid, WasFound<T>> FindDictionaryByLocalIdentity<T>(this IEnumerable<T> items,
            IEnumerable<Guid> localIdentities)
            where T : IIdentityMapping
        {
            var identitiesHash = new HashSet<Guid>(localIdentities);

            var foundItems = items
                .Where(x => identitiesHash.Contains(x.LocalIdentity))
                .Now();

            var notFoundIdentities = identitiesHash.Except(foundItems
                .Select(x => x.LocalIdentity));

            var output = foundItems
                .Select(x => (x.LocalIdentity, WasFound.Found(x)))
                .Concat(notFoundIdentities
                    .Select(x => (x, WasFound.NotFound<T>())))
                .ToDictionary(
                    x => x.Item1,
                    x => x.Item2);

            return output;
        }

        public static WasFound<T> FindSingleByExternalIdentity<T>(this IEnumerable<T> items, Guid identity)
            where T : IIdentityMapping
        {
            var output = items.FindSingle(Instances.Predicate.ExternalIdentityIs<T>(identity));
            return output;
        }

        public static WasFound<T> FindSingleByIdentities<T>(this IEnumerable<T> items, Guid localIdentity, Guid externalIdentity)
            where T : IIdentityMapping
        {
            var output = items.FindSingle(Instances.Predicate.IdentitiesAre<T>(localIdentity, externalIdentity));
            return output;
        }

        public static WasFound<T> FindSingleByLocalIdentity<T>(this IEnumerable<T> items, Guid identity)
            where T : IIdentityMapping
        {
            var output = items.FindSingle(Instances.Predicate.LocalIdentityIs<T>(identity));
            return output;
        }
    }
}