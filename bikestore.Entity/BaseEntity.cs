namespace bikestore.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public int? CreatedById { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedById { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}

