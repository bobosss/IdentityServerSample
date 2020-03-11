using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using Allweb.Core.Common.Utils;

namespace Allweb.Core.Common.Core
{
    /// <summary>
    /// Implements INotifyPropertyChanged
    /// </summary>
    /// <remarks>
    /// Inherited by all classes that need to incorporate property changed event. 
    /// </remarks>
    public class NotificationObject : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged

        private event PropertyChangedEventHandler _propertyChanged;
        private readonly List<PropertyChangedEventHandler> _propertyChangedEventSubscribers = new List<PropertyChangedEventHandler>();
        /// <summary>
        /// Property Changed event handler. 
        /// Uses a private list of event subscribers, in order to check subscriber existance in list and not attach duplicate, preventing double firing events
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_propertyChangedEventSubscribers.Contains(value))
                {
                    _propertyChanged += value;
                    _propertyChangedEventSubscribers.Add(value);
                }
            }
            remove
            {
                _propertyChanged -= value;
                _propertyChangedEventSubscribers.Remove(value);
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Compile time safety overload for getting an object property name with lamda expressions
        /// </summary>
        /// <typeparam name="T">Object</typeparam>
        /// <param name="propertyExpression">Lamda expression for the property to get the name for.</param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            // Property name is retrieved with reflection.
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }

        #endregion
    }
}
