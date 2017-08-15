using System.Collections.Generic;

namespace EFCoreGlobalQueryFilters.Models
{
    public class Playlist : BaseEntity
    {
        public string Title { get; set; }

        public IList<Song> Songs { get; set; }
    }
}
