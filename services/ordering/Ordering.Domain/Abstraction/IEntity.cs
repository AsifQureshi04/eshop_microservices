
namespace Ordering.Domain.Abstraction
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; }
    }
    
    public interface IEntity
    {
        public DateTime? CretedAt { get; set; }
        public string? CretedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? IsActive { get; set; }  
        public bool? IsDeleted { get; set; } 
    }
}
