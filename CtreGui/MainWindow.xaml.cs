using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CtreGui;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Enable_OnClick(object sender, RoutedEventArgs e)
    {
        var vm = (MainViewModel)DataContext;
        vm.IsEnabled = !vm.IsEnabled;

        if (vm.IsEnabled)
        {
            Enable.Content = "Enabled";
            Enable.Background = new SolidColorBrush(Colors.LightGreen);
        }
        else
        {
            Enable.Content = "Disabled";
            Enable.Background = new SolidColorBrush(Colors.LightCoral);
        }
    }

    private void AddMotor_Click(object sender, RoutedEventArgs e)
    {
        var input = IdInput.Text;
        IdInput.Clear();
        
        if (!int.TryParse(input, out var id))
            return;
        
        if (DataContext is not MainViewModel vm)
            return;
        
        if (vm.Motors.Any(motor => motor.CanId == id))
            return;
        
        vm.AddMotor(id);
    }

    private void SpeedSlider_OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        if (sender is not Slider slider)
            return;

        if (slider.DataContext is not Motor motor)
            return;

        motor.Output = 0;
    }

    private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
    {
        if (sender is not Button button)
            return;

        if (button.DataContext is not Motor motor)
            return;

        if (DataContext is not MainViewModel vm)
            return;
        
        vm.Motors.Remove(motor);
        motor.Output = 0;
    }
}