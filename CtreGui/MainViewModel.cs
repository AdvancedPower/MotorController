using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CTRE.Phoenix6.Native;
using Timer = System.Timers.Timer;

namespace CtreGui;

public sealed class MainViewModel : INotifyPropertyChanged
{
    private readonly Timer _heartbeat = new(50);
    public ObservableCollection<Motor> Motors { get; } = [];

    public bool IsEnabled
    {
        get;
        set
        {
            field = value;
            new Action(field ? (Action)_heartbeat.Start : _heartbeat.Stop).Invoke();
            OnPropertyChanged();
        }
    }

    public MainViewModel() => _heartbeat.Elapsed += (_, _) => UnmanagedNative.FeedEnable(0.1);
    
    public void AddMotor(int id) => Motors.Add(new Motor(id));
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}