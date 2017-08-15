using System;
using System.Collections.Generic;

namespace EFCoreGlobalQueryFilters.Services
{
    public interface IEntityTypeProvider
    {
        IEnumerable<Type> GetEntityTypes();
    }
}
