using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0098;
using R5T.T0101;


namespace System
{
    public static class IOperationExtensions
    {
        /// <summary>
        /// Assumes that the local identity of the <see cref="IIdentityMapping"/> is unique.
        /// </summary>
        public static (
            T[] newMappings,
            T[] departedMappings)
        GetNewAndDepartedIdentityMappings<T>(this IOperation _,
            T[] mappings,
            T[] modifiedMappings)
            where T : IIdentityMapping
        {
            // No need to check data values, because we are using a data value-based equality comparer, and the only other field is identity, which will not have been set for the local extension method base objects.
            var newMappings = modifiedMappings.Except(mappings, IdentityMappingEqualityComparer<T>.Instance)
                .ToArray();

            var departedExtensionMethodBases = mappings.Except(modifiedMappings, IdentityMappingEqualityComparer<T>.Instance)
                .ToArray();

            return (newMappings, departedExtensionMethodBases);
        }
    }
}
