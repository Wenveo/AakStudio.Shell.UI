using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Aak.Shell.UI.Showcase.Commands;

internal sealed class RelayCommand<T> : ICommand
{
    private readonly Action<T?> execute;

    private readonly Predicate<T?>? canExecute;

    public event EventHandler? CanExecuteChanged;

    public RelayCommand(Action<T?> execute)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));
        this.execute = execute;
    }

    public RelayCommand(Action<T?> execute, Predicate<T?> canExecute)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));
        ArgumentNullException.ThrowIfNull(canExecute, nameof(canExecute));
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public void NotifyCanExecuteChanged()
    {
        this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool CanExecute(object? parameter)
    {
        return canExecute?.Invoke((T?)parameter) ?? true;
    }

    public void Execute(object? parameter)
    {
        this.execute((T?)parameter);
    }
}