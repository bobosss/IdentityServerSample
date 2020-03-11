﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allweb.Core.Common.Extensions
{
    public static class MefExtensions
    {
        public static CompositionContainer Container;

        public static object GetExportedValueByType(this CompositionContainer container, Type type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var firstOrDefault in partDef.ExportDefinitions
                    .Where(exportDef => exportDef.ContractName == type.FullName)
                    .Select(exportDef => AttributedModelServices.GetContractName(type))
                    .Select(contract => new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne, false, false, CreationPolicy.Any))
                    .Select(definition => container.GetExports(definition).FirstOrDefault())
                    .Where(firstOrDefault => firstOrDefault != null))
                {
                    return firstOrDefault.Value;
                }
            }

            return null;
        }

        public static IEnumerable<object> GetExportedValuesByType(this CompositionContainer container, Type type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type.FullName)
                    {
                        var contract = AttributedModelServices.GetContractName(type);
                        var definition = new ContractBasedImportDefinition(contract, contract, null, ImportCardinality.ExactlyOne,
                                                                           false, false, CreationPolicy.Any);
                        return container.GetExports(definition);
                    }
                }
            }

            return new List<object>();
        }

        public static T GetExportedValue<T>(this CompositionContainer container,
            Func<IDictionary<string, object>, bool> predicate)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == typeof(T).FullName)
                    {
                        if (predicate(exportDef.Metadata))
                            return (T)partDef.CreatePart().GetExportedValue(exportDef);
                    }
                }
            }
            return default(T);
        }

        public static T GetExportedValueByType<T>(this CompositionContainer container, string type)
        {
            foreach (var partDef in container.Catalog.Parts)
            {
                foreach (var exportDef in partDef.ExportDefinitions)
                {
                    if (exportDef.ContractName == type)
                        return (T)partDef.CreatePart().GetExportedValue(exportDef);
                }
            }
            return default(T);
        }
    }
}
