namespace Ordering.Domain.Common
{
    public abstract class EntityBase
    {
        public string Id { get; protected set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; } = string.Empty;
        public DateTime? LastModifiedDate { get; set; }
    }
}
