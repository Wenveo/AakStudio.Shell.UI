using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;

namespace Aak.Shell.UI.Controls
{
    public class TreeListViewCollection : IList<TreeListViewNode>, INotifyCollectionChanged
    {
        private readonly TreeListViewNode _parent;
        private List<TreeListViewNode> _list = new();
        private bool _isRaisingEvent;

        public TreeListViewCollection(TreeListViewNode parent)
        {
            _parent = parent;
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            Debug.Assert(!_isRaisingEvent);
            _isRaisingEvent = true;
            try
            {
                _parent.OnChildrenChanged(e);
                if (CollectionChanged != null)
                    CollectionChanged(this, e);
            }
            finally
            {
                _isRaisingEvent = false;
            }
        }

        private void ThrowOnReentrancy()
        {
            if (_isRaisingEvent)
                throw new InvalidOperationException();
        }

        private void ThrowIfValueIsNullOrHasParent(TreeListViewNode node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (node.NodeParent != null)
                throw new ArgumentException("The node already has a parent", nameof(node));
        }

        public TreeListViewNode this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                ThrowOnReentrancy();
                var oldItem = _list[index];
                if (oldItem == value)
                    return;

                ThrowIfValueIsNullOrHasParent(value);
                _list[index] = value;
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, oldItem, index));
            }
        }

        public int Count
        {
            get { return _list.Count; }
        }

        bool ICollection<TreeListViewNode>.IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(TreeListViewNode node)
        {
            if (node == null || node.NodeParent != _parent)
                return -1;
            else
                return _list.IndexOf(node);
        }

        public void Insert(int index, TreeListViewNode node)
        {
            ThrowOnReentrancy();
            ThrowIfValueIsNullOrHasParent(node);
            _list.Insert(index, node);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, node, index));
        }

        public void InsertRange(int index, IEnumerable<TreeListViewNode> nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));
            ThrowOnReentrancy();

            List<TreeListViewNode> newNodes = nodes.ToList();
            if (newNodes.Count == 0)
                return;

            foreach (TreeListViewNode node in newNodes)
                ThrowIfValueIsNullOrHasParent(node);

            _list.InsertRange(index, newNodes);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newNodes, index));
        }

        public void RemoveAt(int index)
        {
            ThrowOnReentrancy();

            var oldItem = _list[index];
            _list.RemoveAt(index);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
        }

        public void RemoveRange(int index, int count)
        {
            ThrowOnReentrancy();
            if (count == 0)
                return;

            var oldItems = _list.GetRange(index, count);
            _list.RemoveRange(index, count);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItems, index));
        }

        public void Add(TreeListViewNode node)
        {
            ThrowOnReentrancy();
            ThrowIfValueIsNullOrHasParent(node);
            _list.Add(node);
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, node, _list.Count - 1));
        }

        public void AddRange(IEnumerable<TreeListViewNode> nodes)
        {
            InsertRange(Count, nodes);
        }

        public void Clear()
        {
            ThrowOnReentrancy();

            var oldList = _list;
            _list = new List<TreeListViewNode>();
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldList, 0));
        }

        public bool Contains(TreeListViewNode node)
        {
            return IndexOf(node) >= 0;
        }

        public void CopyTo(TreeListViewNode[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public bool Remove(TreeListViewNode item)
        {
            int pos = IndexOf(item);
            if (pos >= 0)
            {
                RemoveAt(pos);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<TreeListViewNode> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public void RemoveAll(Predicate<TreeListViewNode> match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));

            ThrowOnReentrancy();
            int firstToRemove = 0;
            for (int i = 0; i < _list.Count; i++)
            {
                bool removeNode;
                _isRaisingEvent = true;
                try
                {
                    removeNode = match(_list[i]);
                }
                finally
                {
                    _isRaisingEvent = false;
                }
                if (!removeNode)
                {
                    if (firstToRemove < i)
                    {
                        RemoveRange(firstToRemove, i - firstToRemove);
                        i = firstToRemove - 1;
                    }
                    else
                    {
                        firstToRemove = i + 1;
                    }
                    Debug.Assert(firstToRemove == i + 1);
                }
            }
            if (firstToRemove < _list.Count)
            {
                RemoveRange(firstToRemove, _list.Count - firstToRemove);
            }
        }
    }
}
