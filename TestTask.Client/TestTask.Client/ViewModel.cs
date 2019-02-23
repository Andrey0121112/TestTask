using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using TestTask.Client.model;

namespace TestTask.Client
{
    public class ViewModel : INotifyPropertyChanged
    {

        public ServerAPI serverAPI { get; set; }

        public ButtonModel ButtonSeeAll { get; set; }
        public ButtonModel ButtonDelete { get; set; }
        public ButtonModel ButtonChange { get; set; }
        public ButtonModel ButtonSave { get; set; }

        public ButtonModel ButtonCreateNew { get; set; }
        public ButtonModel ButtonClear { get; set; }

        public ObservableCollection<PhoneModel> listItem { get; set; }
        public PhoneModel selectedPhone { get; set; }


        public delegate void Action(ServerAPI serverAPI);

        public delegate void ActionList();

        public ViewModel()
        {
            ListItem = new ObservableCollection<PhoneModel>();

            serverAPI = new ServerAPI();
            serverAPI.ListItem = ListItem;
            serverAPI.selectItem = SelectedPhone;

            Action action = ServiceButton.ApiGetAll;
            ButtonSeeAll = new ButtonModel(action, serverAPI) { Title = "Get all" };
            action = ServiceButton.ApiDelete;
            ButtonDelete = new ButtonModel(action, serverAPI) { Title = "Delete" };
            action = ServiceButton.ApiChange;
            ButtonChange = new ButtonModel(action, serverAPI) { Title = "Change" };
            action = ServiceButton.ApiSave;
            ButtonSave = new ButtonModel(action, serverAPI) { Title = "Save" };

            action = NewItemButton;
            ButtonCreateNew = new ButtonModel(action, serverAPI) { Title = "Create New Item" };
            action = ClearListItem;
            ButtonClear = new ButtonModel(action, serverAPI) { Title = "Clear" };
        }

        public ObservableCollection<PhoneModel> ListItem
        {
            get
            {
                return listItem;
            }
            set
            {
                listItem = value;
                OnPropertyChanged();
            }
        }

        public void ClearListItem(ServerAPI serverAPI)
        {
            ListItem.Clear();
            OnPropertyChanged("ListItem");
            Thread.Sleep(5000);
        }

        public PhoneModel SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged();
            }
        }

        public void NewItemButton(ServerAPI serverAPI)
        {
            SelectedPhone = new PhoneModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
