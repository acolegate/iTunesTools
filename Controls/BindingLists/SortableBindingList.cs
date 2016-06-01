using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CustomControls.BindingLists
{
    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly PropertyDescriptorCollection _propertyDescriptors = TypeDescriptor.GetProperties(typeof(T));
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        public SortableBindingList(IEnumerable<T> enumerable) : base(enumerable.ToList())
        {
        }

        public SortableBindingList()
        {
        }

        protected override bool IsSortedCore
        {
            get
            {
                return _isSorted;
            }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get
            {
                return _sortDirection;
            }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get
            {
                return _sortProperty;
            }
        }

        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        public SortableBindingList<T> Load(IEnumerable<T> enumeration)
        {
            ResetItems(enumeration);
            return this;
        }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _isSorted = true;
            _sortDirection = direction;
            _sortProperty = prop;

            Func<T, object> predicate = n => n.GetType().GetProperty(prop.Name).GetValue(n, null);

            ResetItems(_sortDirection == ListSortDirection.Ascending ? Items.AsParallel().OrderBy(predicate) : Items.AsParallel().OrderByDescending(predicate));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortDirection = base.SortDirectionCore;
            _sortProperty = base.SortPropertyCore;

            ResetBindings();
        }

        private void ResetItems(IEnumerable<T> items)
        {
            RaiseListChangedEvents = false;
            List<T> tempList = items.ToList();
            ClearItems();

            foreach (T item in tempList)
            {
                Add(item);
            }

            RaiseListChangedEvents = true;
            ResetBindings();
        }
    }
}
