namespace JobPortal.Model
{
    public class Designation : BaseEntity
    {
        //public long Id { get; set; }
        public string DesignationName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
