using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private Model.FlightBoardModel model;
        private Setting settingWindow;


        public FlightBoardViewModel()
        {
            model = Model.FlightBoardModel.getInstance();
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged(e.PropertyName);

            };
        }
        public double Lon
        {
            get { return model.Lon; }
        }

        public double Lat
        {
            get { return model.Lat; }
        }


        #region Commands
        #region SettingCommand
        private ICommand _settingCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return _settingCommand ?? (_settingCommand = new CommandHandler(() => OnSetting()));
            }
        }
        private void OnSetting()
        {

            settingWindow = new Setting();
            settingWindow.Show();
        }
        #endregion

        #region ConnectCommand
        private ICommand _connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new CommandHandler(() => OnConnect()));
            }
        }
        private void OnConnect()
        {
            model.Connect();
        }
        #endregion
        #endregion
    }
}