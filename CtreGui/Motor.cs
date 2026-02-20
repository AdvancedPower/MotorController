using System.ComponentModel;
using System.Runtime.CompilerServices;
using CTRE.Phoenix6.Controls;
using CTRE.Phoenix6.Hardware;

namespace CtreGui;

public sealed class Motor(int id) : INotifyPropertyChanged
{
    private readonly TalonFX _motor = new(id);
    public int CanId => _motor.DeviceID;

    public double Output
    {
        get;
        set
        {
            field = value;
            _motor.SetControl(new DutyCycleOut(field / 100));
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}