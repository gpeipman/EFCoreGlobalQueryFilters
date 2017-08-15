namespace EFCoreGlobalQueryFilters.Models
{
    public class Song : BaseEntity
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
    }
}
