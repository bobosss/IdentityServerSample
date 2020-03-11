using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using Allweb.Core.Common.Contracts;
using Allweb.Core.Common.Extensions;
using Allweb.Core.Common.Utils;

namespace Allweb.Core.Common.Core
{
    /// <summary>
    /// Implements INotifyPropertyChanged, IDirtyCapable
    /// </summary>
    /// <remarks>
    /// Inherited by all classes that need to incorporate property changed event. 
    /// Also taking advantage of that, makes an "IsDirty" state available in all subclasses.
    /// </remarks>
    public abstract class ObjectBase : NotificationObject, IDirtyCapable, IExtensibleDataObject, IEntityState
    {

        protected bool _isDirty;

        /// <summary>
        /// Holds object status. Is not persisted in database
        /// </summary>
        public virtual bool IsDirty
        {
            get { return _isDirty; }
            protected set
            {
                _isDirty = value;
                OnPropertyChanged(() => IsDirty, false);
            }
        }

        /// <summary>
        /// Public static Property for MEF Dependency Injection.
        /// </summary>
        public static CompositionContainer Container { get; set; }

        #region Handle Notifications - Override NotificationObject methods

        protected override void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged(string propertyName, bool markDirty)
        {
            base.OnPropertyChanged(propertyName);

            if (markDirty)
                IsDirty = true;
        }

        /// <summary>
        /// Compile time safety overload for getting an object property name with lamda expressions
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="propertyExpression">Lamda expression for the property to get the name for.</param>
        /// <param name="markDirty">Mark the object as "Dirty" (Modified)</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression, bool markDirty)
        {
            // Property name is retrieved with reflection.
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName, markDirty);
        }

        #endregion

        #region IExtensibleDataObject Members

        public ExtensionDataObject ExtensionData { get; set; }

        #endregion
        
        #region Protected methods

        /// <summary>
        /// General purpose object method. Traverses the object graph (object and its related objects). Assumes that objects traversed are subclasses of ObjectBase (this).
        /// </summary>
        /// <param name="snippetForObject">Code snippet (delegate to invoke for object). Code to execute for object, also condition to exit recursion. </param>
        /// <param name="snippetForCollection">Code snippet (delegate to invoke for Collections in object). </param>
        /// <param name="exemptProperties">Properties of the object to exclude from traversing</param>
        protected void WalkObjectGraph(Func<ObjectBase, bool> snippetForObject,
                                       Action<IList> snippetForCollection,
                                       params string[] exemptProperties)
        {
            List<ObjectBase> visited = new List<ObjectBase>();
            Action<ObjectBase> walk = null;

            List<string> exemptions = new List<string>();
            if (exemptProperties != null)
                exemptions = exemptProperties.ToList();

            // Define walk Action (Action method body)
            walk = (o) =>
            {
                if (o != null && !visited.Contains(o))
                {
                    visited.Add(o);

                    // Execution of the snippet (act on object). Boolean value returned to be used as exit condition
                    bool exitWalk = snippetForObject.Invoke(o);
                    // Exit Condition
                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            // Check if property is excluded (third param)
                            if (!exemptions.Contains(property.Name))
                            {
                                // If property is a class of type ObjectBase, execute recursion
                                if (property.PropertyType.IsSubclassOf(typeof(ObjectBase)))
                                {
                                    ObjectBase obj = (ObjectBase)(property.GetValue(o, null));
                                    walk(obj);
                                }
                                else
                                {
                                    // If property is a collection (as IList and check against null) invoke code snippet for Collecions 
                                    // and in case collection item is ObjectBase execute recursion with that object.
                                    IList coll = property.GetValue(o, null) as IList;
                                    if (coll != null)
                                    {
                                        snippetForCollection.Invoke(coll);

                                        foreach (object item in coll)
                                        {
                                            if (item is ObjectBase)
                                                walk((ObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };

            // Invoke the action (Start the recursion)
            walk(this);
        }

        #endregion


        #region IDirtyCapable Members
        public bool IsAnythingDirty()
        {
            bool isDirty = false;

            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                {
                    isDirty = true;
                    return true;
                }
                else
                {
                    return false;
                }
            },
            coll => { });

            return isDirty;
        }

        List<IDirtyCapable> IDirtyCapable.GetDirtyObjects()
        {
            List<IDirtyCapable> dirtyObjects = new List<IDirtyCapable>();

            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                    dirtyObjects.Add(o);

                return false;
            }, coll => { });

            return dirtyObjects;
        }

        public void CleanAll()
        {
            WalkObjectGraph(
            o =>
            {
                if (o.IsDirty)
                    o.IsDirty = false;
                return false;
            }, coll => { });
        }

        #endregion

        /// <summary>
        /// Client Date Created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Client Date Modified
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Client CreatedBy UserId
        /// </summary>
        public int CreatedBy { get; set; }

        /// <summary>
        /// Client ModifiedBy UserId
        /// </summary>
        public int ModifiedBy { get; set; }

        /// <summary>
        /// Client State
        /// </summary>
        public State State { get; set; }

        #region Custom Equality Code

        //public override bool Equals(object obj)
        //{
        //    if (this == obj)
        //        return true;
        //    if (obj == null || GetType() != obj.GetType())
        //        return false;
        //    var other = (GetType()) obj;  // this should be solid Type


        //    return Id = other.Id;

        //}

        //public override int GetHashCode()
        //{
        //    return Id.GetHashCode();
        //}

        #endregion
    }
}
