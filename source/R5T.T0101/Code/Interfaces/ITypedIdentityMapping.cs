using System;


namespace R5T.T0101
{
    public interface ITypedIdentityMapping<TLocalIdentity, TExternalIdentity>
    {
        public TLocalIdentity LocalIdentity { get; set; }
        public TExternalIdentity ExternalIdentity { get; set; }
    }
}