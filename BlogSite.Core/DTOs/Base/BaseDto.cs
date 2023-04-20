namespace BlogSite.Core.DTOs.Base
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
