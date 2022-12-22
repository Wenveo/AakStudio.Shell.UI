using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace VisualStudio.Shell.UI.Controls
{
    public class TreeListViewNode : INotifyPropertyChanged
    {
        public bool IsExpanded
        {
            get => this.isExpanded;
            set
            {
                var oldValue = this.isExpanded;
                this.SetProperty(ref this.isExpanded, value, nameof(IsExpanded));
                this.OnIsExpandedChanged(new RoutedPropertyChangedEventArgs<bool>(oldValue, value));
            }
        }

        public object? Content
        {
            get => this.content;
            set
            {
                var oldValue = this.content;
                this.SetProperty(ref this.content, value, nameof(Content));
                this.OnContentChanged(new RoutedPropertyChangedEventArgs<object?>(oldValue, value));
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
                if (this.NodeParent is null || this.NodeParent.IsRoot)
                    return 0;
                return this.NodeParent.Level + 1;
            }
        }

        public Thickness LevelPadding => new(12 * Level, 0, 0, 0);

        internal bool IsLoaded
        {
            get => this.isLoaded;
            set
            {
                if (this.isLoaded == value)
                    return;

                this.isLoaded = value;
                if (this.isLoaded)
                    this.Loaded?.Invoke(this, new RoutedEventArgs());
                else
                    this.UnLoaded?.Invoke(this, new RoutedEventArgs());
            }
        }

        public TreeListViewNode()
        {
            this.Children = new TreeListViewCollection(this);
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
            this.ContentChanged?.Invoke(this, e);
        }

        public virtual void OnIsExpandedChanged(RoutedPropertyChangedEventArgs<bool> e)
        {
            this.ExpandedChanged?.Invoke(this, e);
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

            if (this.IsExpanded && this.HasItems)
            {
                foreach (var child in this.Children)
                {
                    var nodes = child.ToList();
                    list.AddRange(nodes);
                }
            }
            return list;
        }

        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetProperty<T>(ref T property, T newValue, [CallerMemberName] string? propertyName = null)
        {
            property = newValue;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
