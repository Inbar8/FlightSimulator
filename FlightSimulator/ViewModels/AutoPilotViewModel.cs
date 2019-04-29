using System.Windows.Input;
using System.Windows.Media;
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        // AutoPilotViewModel members
        private AutoPilotModel model;
        private string commandsToSend;
        private Brush backgroundColor = Brushes.White;

        #region Properties
        public string CommandsToSend
        {
            get { return commandsToSend; }
            set
            {
                commandsToSend = value;
                if (CommandsToSend != "" && BackgroundColor == Brushes.White)
                {
                    BackgroundColor = Brushes.LightSalmon;
                }
                else if (CommandsToSend == "")
                {
                    BackgroundColor = Brushes.White;
                }
            }
        }
        public Brush BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                NotifyPropertyChanged("BackgroundColor");
            }
        }
        #endregion

        // AutoPilotViewModel constructor
        public AutoPilotViewModel()
        {
            model = new AutoPilotModel();
        }

        // okButton Part
        #region okButton
        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() =>
                {
                    string sendText = CommandsToSend;
                    CommandsToSend = "";
                    NotifyPropertyChanged(CommandsToSend);
                    BackgroundColor = Brushes.White;
                    model.SendCommands(sendText);
                }));
            }
        }
        #endregion

        // clearButton Part
        #region clearButton
        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() =>
                {
                    CommandsToSend = "";
                    BackgroundColor = Brushes.White;
                    NotifyPropertyChanged(CommandsToSend);
                }));
            }
        }
        #endregion
    }
}
