using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestTask.Client.model
{
    public class ButtonModel : INotifyPropertyChanged
    {
        private string title;
        private bool _canExecute = false;
        private ICommand _clickCommand;

        public Delegate _action;
        public ServerAPI _pars;

        public ButtonModel(Delegate action, ServerAPI serverAPI)
        {
            _canExecute = true;
            _action = action;
            _pars = serverAPI;
            Title = action.Method.Name;
        }

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }
        public ICommand ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new CommandHandler(() => Action(), _canExecute));
            }
        }

        public void Action()
        {
            _action.DynamicInvoke(_pars);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
