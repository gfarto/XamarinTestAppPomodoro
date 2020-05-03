using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class RootPageViewModel : NotificationObject
    {
        private ObservableCollection<string> menuItems;
        private string selectedMenuItem;

        public RootPageViewModel()
        {
            this.menuItems = new ObservableCollection<string>();
            this.menuItems.Add("Pomodoro");
            this.menuItems.Add("Configuración");
            this.menuItems.Add("Histórico");

            this.PropertyChanged += RootPageViewModel_PropertyChanged;

            this.SelectedMenuItem = "Pomodoro";
        }

        private void RootPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(this.SelectedMenuItem))
            {
                if (this.SelectedMenuItem == "Pomodoro")
                {
                    MessagingCenter.Send(this, "GoToPomodoro");
                }
                if (this.SelectedMenuItem == "Configuración")
                {
                    MessagingCenter.Send(this, "GoToConfiguration");
                }
                if (this.SelectedMenuItem == "Histórico")
                {
                    MessagingCenter.Send(this, "GoToHistory");
                }
            }
        }

        public ObservableCollection<string> MenuItems
        {
            get
            {
                return this.menuItems;
            }
            set
            {
                this.menuItems = value;
                this.OnPropertyChanged();
            }
        }

        public string SelectedMenuItem
        {
            get { return this.selectedMenuItem; }
            set
            {
                this.selectedMenuItem = value;
                this.OnPropertyChanged();
            }
        }
    }
}
