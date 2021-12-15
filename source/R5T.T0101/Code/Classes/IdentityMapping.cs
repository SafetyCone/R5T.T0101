using System;


namespace R5T.T0101
{
    public class IdentityMapping : IIdentityMapping
    {
        public Guid LocalIdentity { get; set; }
        public Guid ExternalIdentity { get; set; }
    }
}
