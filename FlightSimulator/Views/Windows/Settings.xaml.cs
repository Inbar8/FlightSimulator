using System;
using System.Windows;
using FlightSimulator.Model;
using FlightSimulator.ViewModels.Windows;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel(this);
        }
    }
}
