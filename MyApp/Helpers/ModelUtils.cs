using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using MyApp.Models;

namespace MyApp.Helpers
{
    public static class ModelUtils
    {
        private static readonly Dictionary<string, Type> typeCache = new Dictionary<string, Type>();
        private static List<Type> ModelTypes = null;

        public static Type ResolveType(string name) {
            name = name.ToLower();
            lock (typeCache)
            {
                if (!typeCache.ContainsKey(name))
                {
                    if (ModelTypes == null)
                    {
                        lock (ModelTypes)
                        {
                            var assembly = Assembly.Load(new AssemblyName("MyApp.Models"));
                            ModelTypes = assembly.ExportedTypes.ToList();
                        }
                    }
                    var resolvedType = ModelTypes?.FirstOrDefault(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                    typeCache[name] = resolvedType;
                    return resolvedType;
                }

            }
            return typeCache[name];
        }
    }
}
