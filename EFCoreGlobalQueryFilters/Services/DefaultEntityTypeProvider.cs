using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using EFCoreGlobalQueryFilters.Models;
using Microsoft.Extensions.DependencyModel;

namespace EFCoreGlobalQueryFilters.Services
{
    public class DefaultEntityTypeProvider : IEntityTypeProvider
    {
        private static IList<Type> _entityTypeCache;

        public IEnumerable<Type> GetEntityTypes()
        {
            if (_entityTypeCache != null)
            {
                return _entityTypeCache.ToList();
            }

            _entityTypeCache = (from a in GetReferencingAssemblies()
                                from t in a.DefinedTypes
                                where t.BaseType == typeof(BaseEntity)
                                select t.AsType()).ToList();

            return _entityTypeCache;
        }

        private static IEnumerable<Assembly> GetReferencingAssemblies()
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;

            foreach (var library in dependencies)
            {
                try
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
                catch (FileNotFoundException)
                { }
            }
            return assemblies;
        }
    }
}
