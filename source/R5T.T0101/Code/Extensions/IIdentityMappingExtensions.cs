using System;

using R5T.T0101;


namespace System
{
    public static class IIdentityMappingExtensions
    {
        public static string ToStringRepresentation(this IIdentityMapping mapping)
        {
            var output = $"Local: {mapping.LocalIdentity}, External: {mapping.ExternalIdentity}";
            return output;
        }
    }
}

namespace R5T.T0101
{
    public static class IIdentityMappingExtensions
    {
        public static IdentityMapping ToIdentityMapping(this IIdentityMapping identityMapping)
        {
            var output = new IdentityMapping
            {
                LocalIdentity = identityMapping.LocalIdentity,
                ExternalIdentity = identityMapping.ExternalIdentity,
            };

            return output;
        }
    }
}
