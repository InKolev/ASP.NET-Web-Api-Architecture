namespace Sample.Data.Common.Contracts
{
    using System;

    public interface IAuditableInfo
    {
        DateTime CreatedOn { get; set; }

        bool PreserveCreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}