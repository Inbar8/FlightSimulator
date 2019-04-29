using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightBoardModel model;
        private Settings settings = new Settings();

        public FlightBoardViewModel()
        {
            model = new FlightBoardModel();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat") { Lat = model.Lat; }
                if (e.PropertyName == "Lon") { Lon = model.Lon; }
                NotifyPropertyChanged(e.PropertyName);
            };
        }

        private double lon;
        public double Lon
        {
            get { return lon; }
            set {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        private double lat;
        public double Lat
        {
            get { return lat; }
            set {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        #region Commands
        #region SettingsCommand
        private ICommand settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() => OnSettings()));
            }
        }

        private void OnSettings()
        {
            settings = new Settings();
            settings.Show();
        }
        #endregion

        #region ConnectCommand
        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return connectCommand ?? (connectCommand = new CommandHandler(() => OnConnect()));
            }
        }

        private void OnConnect()
        {
            new Thread(delegate ()
            {
                Commands.Instance.ConnectToHost(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort);
            }).Start();
            model.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort);
        }
        #endregion
        #endregion
    }
}