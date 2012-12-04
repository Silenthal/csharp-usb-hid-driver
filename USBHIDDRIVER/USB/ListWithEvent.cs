/*****************************************************************************
*                                                                            *
* HID USB DRIVER - FLORIAN LEITNER                                           *
* Copyright 2007 - Florian Leitner | http://www.florian-leitner.de           *
* mail@florian-leitner.de                                                    *
*                                                                            *
* This file is part of HID USB DRIVER.                                       *
*                                                                            *
*   HID USB DRIVER is free software; you can redistribute it and/or modify   *
*   it under the terms of the GNU General Public License 3.0 as published by *
*   the Free Software Foundation;                                            *
*   HID USB DRIVER is distributed in the hope that it will be useful,        *
*   but WITHOUT ANY WARRANTY; without even the implied warranty of           *
*   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the            *
*   GNU General Public License for more details.                             *
*   You should have received a copy of the GNU General Public License        *
*   along with this program.  If not, see <http://www.gnu.org/licenses/>.    *
*                                                                            *
******************************************************************************/

namespace USBHIDDRIVER.List
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a generic <see cref="System.Collections.Generic.List&lt;T>"/>, with notifications on item additions.
    /// </summary>
    public class ListWithEvent<T> : List<T>
    {
        private object syncRoot = new object();

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="ListWithEvent&lt;T>"/>.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        /// <summary>
        /// Occurs when an item is added to the <see cref="ListWithEvent&lt;T>"/>.
        /// </summary>
        public event EventHandler ItemAdded;

        /// <summary>
        /// Raises the <see cref="ItemAdded"/> event with the provided arguments.
        /// </summary>
        /// <param name="e">Arguments of the event being raised.</param>
        protected virtual void OnItemAdded(System.EventArgs e)
        {
            if (ItemAdded != null)
            {
                ItemAdded(this, e);
            }
        }

        /// <summary>
        /// Adds an object to the end of the <see cref="ListWithEvent&lt;T>"/>.
        /// </summary>
        /// <param name="item">The object to be added to the end of the <see cref="ListWithEvent&lt;T>"/>.</param>
        public new void Add(T item)
        {
            base.Add(item);
            OnItemAdded(EventArgs.Empty);
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the <see cref="ListWithEvent&lt;T>"/>.
        /// </summary>
        /// <param name="collection">The collection whose elements should be added to the end of the <see cref="ListWithEvent&lt;T>"/>. The collection itself cannot be null, but it can contain elements that are null, if type T is a reference type.</param>
        public new void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            OnItemAdded(EventArgs.Empty);
        }
    }
}