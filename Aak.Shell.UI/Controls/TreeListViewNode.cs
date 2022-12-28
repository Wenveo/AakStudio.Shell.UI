using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Aak.Shell.UI.Controls
{
    public class TreeListViewNode : INotifyPropertyChanged
    {
        public bool IsExpanded
        {
            get => isExpanded;
            set
            {
                var oldValue = isExpanded;
                SetProperty(ref isExpanded, value, nameof(IsExpanded));
                OnIsExpandedChanged(new RoutedPropertyChangedEventArgs<bool>(oldValue, value));
            }
        }

        public object? Content
        {
            get => content;
            set
            {
                var oldValue = content;
                SetProperty(ref content, value, nameof(Content));
                OnContentChanged(new RoutedPropertyChangedEventArgs<object?>(oldValue, value));
            }
        }

        public TreeListViewNode? NodeParent { get; internal set; }

        public TreeListViewItem? Container { get; internal set; }

        public TreeListViewCollection Children { get; internal set; }

        public bool IsRoot { get; internal set; }

        public bool HasItems => Children.Any();

        public int Level
        {
            get
            {
                if (NodeParent is null || NodeParent.IsRoot)
                    return 0;
                return NodeParent.Level + 1;
            }
        }

        public Thickness LevelPadding => new(12 * Level, 0, 0, 0);

        internal bool IsLoaded
        {
            get => isLoaded;
            set
            {
                if (isLoaded == value)
                    return;

                isLoaded = value;
                if (isLoaded)
                    Loaded?.Invoke(this, new RoutedEventArgs());
                else
                    UnLoaded?.Invoke(this, new RoutedEventArgs());
            }
        }

        public TreeListViewNode()
        {
            Children = new TreeListViewCollection(this);
        }

        private bool isLoaded;
        private bool isExpanded;
        private object? content;
        public event RoutedPropertyChangedEventHandler<bool>? ExpandedChanged;
        public event RoutedPropertyChangedEventHandler<object?>? ContentChanged;
        public event PropertyChangedEventHandler? PropertyChanged;
        public event RoutedEventHandler? Loaded;
        public event RoutedEventHandler? UnLoaded;

        public virtual void OnContentChanged(RoutedPropertyChangedEventArgs<object?> e)
        {
            ContentChanged?.Invoke(this, e);
        }

        public virtual void OnIsExpandedChanged(RoutedPropertyChangedEventArgs<bool> e)
        {
            ExpandedChanged?.Invoke(this, e);
        }

        public virtual void OnChildrenChanged(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems is not null)
            {
                foreach (var item in e.NewItems)
                {
                    if (item is TreeListViewNode node)
                        node.NodeParent = this;
                }
            }
            if (e.OldItems is not null)
            {
                foreach (var item in e.OldItems)
                {
                    if (item is TreeListViewNode node)
                        node.NodeParent = null;
                }
            }
        }

        internal List<TreeListViewNode> ToList()
        {
            var list = new List<TreeListViewNode>
            {
                this
            };

            if (IsExpanded && HasItems)
            {
                foreach (var child in Children)
                {
                    var nodes = child.ToList();
                    list.AddRange(nodes);
                }
            }
            return list;
        }

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T property, T newValue, [CallerMemberName] string? propertyName = null)
        {
            property = newValue;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
