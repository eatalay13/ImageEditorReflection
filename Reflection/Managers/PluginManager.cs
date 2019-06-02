using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Reflection.Interfaces;

namespace Reflection.Managers
{
    public class PluginManager : IPluginService
    {
        private readonly Dictionary<string, IFilter> _filters = new Dictionary<string, IFilter>();

        public Dictionary<string, IFilter> LoadFilters(string folder)
        {
            _filters.Clear();
            foreach (var dll in Directory.GetFiles(folder, "*.dll"))
                try
                {
                    var asm = Assembly.LoadFrom(dll);
                    foreach (var type in asm.GetTypes())
                        if (type.GetInterface("IFilter") == typeof(IFilter))
                        {
                            if (Activator.CreateInstance(type) is IFilter filter)
                                _filters[filter.Name] = filter;
                        }
                }
                catch (BadImageFormatException)
                {
                    Console.WriteLine();
                    throw;
                }

            return _filters;
        }
    }
}