using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Allweb.Core.Common.Core;

namespace Allweb.Core.Common.Utils
{
    public static class SimpleMapper
    {
        public static void PropertyMap<T, TD>(T source, TD destination, IList<string> excludedProperties = null)
            where T : class, new()
            where TD : class, new()
        {
            List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
            List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

            if (excludedProperties == null)
                excludedProperties = new List<string>();

            IEnumerable<string> queryEntityBaseFields = typeof(EntityBase).GetProperties().Select(f => f.Name);

            foreach (var fieldName in queryEntityBaseFields)
            {
                excludedProperties.Add(fieldName);
            }

            foreach (var sourceProperty in sourceProperties)
            {

                if (excludedProperties.Contains(sourceProperty.Name))
                    continue;



                PropertyInfo destinationProperty =
                    destinationProperties.Find(property => property.Name == sourceProperty.Name);

                if (destinationProperty == null ||
                    Equals(sourceProperty.GetValue(source), destinationProperty.GetValue(destination)))
                    continue;
                try
                {
                    var sourcePropertyValue = sourceProperty.GetValue(source, null);
                    if (sourcePropertyValue is IList)
                    {

                        var iListSourceProperty = (sourcePropertyValue as IList);

                        if (destinationProperty.GetValue(destination, null) is IEnumerable
                            && destinationProperty.PropertyType.IsGenericType)
                        {


                            var destinationPropertyValue = destinationProperty.GetValue(destination) as IEnumerable;

                            MethodInfo addMethodInfo =
                                destinationPropertyValue
                                    .GetType()
                                    .GetMethods()
                                    .FirstOrDefault(
                                        method => method.Name == "Add" && method.GetParameters().Count() == 1);

                            MethodInfo containsMethodInfo =
                                destinationPropertyValue
                                    .GetType()
                                    .GetMethods()
                                    .FirstOrDefault(
                                        method => method.Name == "Contains" && method.GetParameters().Count() == 1);
                            MethodInfo clearMethodInfo =
                                 destinationPropertyValue
                                     .GetType()
                                     .GetMethods()
                                     .FirstOrDefault(
                                         method => method.Name == "Clear" && !method.GetParameters().Any());
                            MethodInfo removeMethodInfo =
                                 destinationPropertyValue
                                     .GetType()
                                     .GetMethods()
                                     .FirstOrDefault(
                                         method => method.Name == "Remove" && method.GetParameters().Count() == 1);


                            ArrayList removedItemsList = new ArrayList();

                            foreach (var collectionItem in destinationPropertyValue)
                            {
                                var item = collectionItem;

                                if (!iListSourceProperty.Contains(item))
                                {
                                    removedItemsList.Add(collectionItem);
                                    //removeMethodInfo?.Invoke(destinationPropertyValue, new[] { collectionItem });
                                }
                            }

                            foreach (var item in removedItemsList)
                            {
                                removeMethodInfo?.Invoke(destinationPropertyValue, new[] {item});
                            }
                        }



                        //    //sourceProperty contains the List
                        //    //get the list object
                        //    IList instanceSource = sourceProperty.GetValue(source, null) as IList;
                        //    IList instanceTarget = destinationProperty.GetValue(destination, null) as IList;

                        //    int i = 0;
                        //    int targetLength = ((IList)instanceTarget).Count;
                        //    int sourceLength = ((IList)instanceSource).Count;
                        //    //extract inner properties
                        //    var sourcePropListProps = sourceProperty.PropertyType.GetGenericArguments()[0]
                        //        .GetProperties().ToList<PropertyInfo>();
                        //    var destinationPropListProps = destinationProperty.PropertyType.GetGenericArguments()[0]
                        //        .GetProperties().ToList<PropertyInfo>();
                        //    foreach (var listInstanceSourceItem in instanceSource)
                        //    {
                        //        int currentSourceId = (int)sourcePropListProps.Find(x => x.Name == "Id")
                        //            .GetValue(listInstanceSourceItem, null);
                        //        if (i <= targetLength - 1)
                        //        {
                        //            var listInstanceTargetItem = instanceTarget[i];
                        //            int currentTargetId = (int)destinationPropListProps.Find(x => x.Name == "Id")
                        //                .GetValue(listInstanceTargetItem, null);
                        //            if (currentSourceId != currentTargetId)
                        //            {
                        //                instanceTarget.Remove(instanceTarget[i]);
                        //                i++;
                        //                continue;
                        //            }

                        //            foreach (var sourcePropListProp in sourcePropListProps)
                        //            {
                        //                if (sourcePropListProp.Name == "DateCreated" || sourcePropListProp.Name == "DateModified" ||
                        //                    sourcePropListProp.Name == "ExtensionData" || sourcePropListProp.Name == "Person" ||
                        //                    sourcePropListProp.Name == "Id" || sourcePropListProp.Name == "Researchers")
                        //                    continue;

                        //                PropertyInfo destinationPropListProp =
                        //                    destinationPropListProps.Find(property => property.Name == sourcePropListProp.Name);

                        //                if (destinationPropListProp != null &&
                        //                    !Equals(sourcePropListProp.GetValue(listInstanceSourceItem, null),
                        //                        destinationPropListProp.GetValue(listInstanceTargetItem, null)))
                        //                {
                        //                    destinationPropListProp.SetValue(listInstanceTargetItem, sourcePropListProp.GetValue(listInstanceSourceItem, null), null);
                        //                }
                        //            }
                        //        }
                        //        else
                        //        {
                        //            instanceTarget.Add(instanceSource[i]);
                        //        }
                        //        i++;
                        //    }
                        //    targetLength = ((IList)instanceTarget).Count;
                        //    if (sourceLength < targetLength)
                        //    {
                        //        for (int j = i; j < targetLength; j++)
                        //        {
                        //            instanceTarget.RemoveAt(j);
                        //        }
                        //    }
                    }
                    else
                        destinationProperty.SetValue(destination, sourceProperty.GetValue(source, null), null);
                }
                catch (ArgumentException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
