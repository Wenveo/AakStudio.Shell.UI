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
            this._parent = parent;
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        private void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            Debug.Assert(!this._isRaisingEvent);
            this._isRaisingEvent = true;
            try
            {
                this._parent.OnChildrenChanged(e);
                if (this.CollectionChanged != null)
                    this.CollectionChanged(this, e);
            }
            finally
            {
                this._isRaisingEvent = false;
            }
        }

        private void ThrowOnReentrancy()
        {
            if (this._isRaisingEvent)
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
                return this._list[index];
            }
            set
            {
                this.ThrowOnReentrancy();
                var oldItem = this._list[index];
                if (oldItem == value)
                    return;

                this.ThrowIfValueIsNullOrHasParent(value);
                this._list[index] = value;
                this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, value, oldItem, index));
            }
        }

        public int Count
        {
            get { return this._list.Count; }
        }

        bool ICollection<TreeListViewNode>.IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(TreeListViewNode node)
        {
            if (node == null || node.NodeParent != this._parent)
                return -1;
            else
                return this._list.IndexOf(node);
        }

        public void Insert(int index, TreeListViewNode node)
        {
            this.ThrowOnReentrancy();
            this.ThrowIfValueIsNullOrHasParent(node);
            this._list.Insert(index, node);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, node, index));
        }

        public void InsertRange(int index, IEnumerable<TreeListViewNode> nodes)
        {
            if (nodes == null)
                throw new ArgumentNullException(nameof(nodes));
            this.ThrowOnReentrancy();

            List<TreeListViewNode> newNodes = nodes.ToList();
            if (newNodes.Count == 0)
                return;

            foreach (TreeListViewNode node in newNodes)
                this.ThrowIfValueIsNullOrHasParent(node);

            this._list.InsertRange(index, newNodes);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newNodes, index));
        }

        public void RemoveAt(int index)
        {
            this.ThrowOnReentrancy();

            var oldItem = this._list[index];
            this._list.RemoveAt(index);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItem, index));
        }

        public void RemoveRange(int index, int count)
        {
            this.ThrowOnReentrancy();
            if (count == 0)
                return;

            var oldItems = this._list.GetRange(index, count);
            this._list.RemoveRange(index, count);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldItems, index));
        }

        public void Add(TreeListViewNode node)
        {
            this.ThrowOnReentrancy();
            this.ThrowIfValueIsNullOrHasParent(node);
            this._list.Add(node);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, node, _list.Count - 1));
        }

        public void AddRange(IEnumerable<TreeListViewNode> nodes)
        {
            this.InsertRange(this.Count, nodes);
        }

        public void Clear()
        {
            this.ThrowOnReentrancy();

            var oldList = this._list;
            this._list = new List<TreeListViewNode>();
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, oldList, 0));
        }

        public bool Contains(TreeListViewNode node)
        {
            return this.IndexOf(node) >= 0;
        }

        public void CopyTo(TreeListViewNode[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        public bool Remove(TreeListViewNode item)
        {
            int pos = this.IndexOf(item);
            if (pos >= 0)
            {
                this.RemoveAt(pos);
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<TreeListViewNode> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        public void RemoveAll(Predicate<TreeListViewNode> match)
        {
            if (match == null)
                throw new ArgumentNullException(nameof(match));

            this.ThrowOnReentrancy();
            int firstToRemove = 0;
            for (int i = 0; i < this._list.Count; i++)
            {
                bool removeNode;
                this._isRaisingEvent = true;
                try
                {
                    removeNode = match(_list[i]);
                }
                finally
                {
                    this._isRaisingEvent = false;
                }
                if (!removeNode)
                {
                    if (firstToRemove < i)
                    {
                        this.RemoveRange(firstToRemove, i - firstToRemove);
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
                this.RemoveRange(firstToRemove, this._list.Count - firstToRemove);
            }
        }
    }
}
