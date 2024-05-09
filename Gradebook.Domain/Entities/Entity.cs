namespace Gradebook.Domain.Entities {
    public abstract class Entity {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
