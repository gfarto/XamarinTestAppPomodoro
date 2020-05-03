using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class ConfigurationPageViewModel : NotificationObject
    {
        private ObservableCollection<int> pomodoroDurations;
        private ObservableCollection<int> breakDurations;
        private int selectedPomodoroDuration;
        private int selectedBreakDuration;

        public ConfigurationPageViewModel()
        {
            this.SaveCommand = new Command(SaveCommandExecute);

            this.loadConfiguration();

            this.loadPomodoroDurations();
            this.loadBreakDurations();
        }

        public ObservableCollection<int> PomodoroDurations
        {
            get { return this.pomodoroDurations; }
            set
            {
                this.pomodoroDurations = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<int> BreakDurations
        {
            get { return this.breakDurations; }
            set
            {
                this.breakDurations = value;
                this.OnPropertyChanged();
            }
        }

        public int SelectedPomodoroDuration
        {
            get { return this.selectedPomodoroDuration; }
            set
            {
                this.selectedPomodoroDuration = value;
                this.OnPropertyChanged();
            }
        }

        public int SelectedBreakDuration
        {
            get { return this.selectedBreakDuration; }
            set
            {
                this.selectedBreakDuration = value;
                this.OnPropertyChanged();
            }
        }

        public ICommand SaveCommand { get; set; }

        public async void SaveCommandExecute()
        {
            Application.Current.Properties[Literals.POMODORO_DURATION] = this.SelectedPomodoroDuration;
            Application.Current.Properties[Literals.BREAK_DURATION] = this.SelectedBreakDuration;

            await Application.Current.SavePropertiesAsync();
        }

        private void loadPomodoroDurations()
        {
            this.PomodoroDurations = new ObservableCollection<int>();
            this.PomodoroDurations.Add(5);
            this.PomodoroDurations.Add(25);
            this.PomodoroDurations.Add(30);
            this.PomodoroDurations.Add(60);
            this.PomodoroDurations.Add(120);
        }

        private void loadBreakDurations()
        {
            this.BreakDurations = new ObservableCollection<int>();
            this.BreakDurations.Add(1);
            this.BreakDurations.Add(5);
            this.BreakDurations.Add(10);
            this.BreakDurations.Add(15);
        }

        private void loadConfiguration()
        {
            if (Application.Current.Properties.ContainsKey(Literals.POMODORO_DURATION))
                this.SelectedPomodoroDuration = (int)Application.Current.Properties[Literals.POMODORO_DURATION];

            if (Application.Current.Properties.ContainsKey(Literals.BREAK_DURATION))
                this.SelectedBreakDuration = (int)Application.Current.Properties[Literals.BREAK_DURATION];
        }
    }
}
