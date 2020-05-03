using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Pomodoro.ViewModels
{
    public class HistoryPageViewModel : NotificationObject
    {
        private ObservableCollection<DateTime> pomodoros;

        public HistoryPageViewModel()
        {
            this.loadPomodorosHistory();
        }

        public ObservableCollection<DateTime> Pomodoros
        {
            get => this.pomodoros;
            set
            {
                this.pomodoros = value;
                this.OnPropertyChanged();
            }
        }

        private void loadPomodorosHistory()
        {
            List<DateTime> history = null;
            if (Application.Current.Properties.ContainsKey(Literals.HISTORY))
            {
                var json = Application.Current.Properties[Literals.HISTORY].ToString();
                if (!string.IsNullOrWhiteSpace(json))
                    history = Newtonsoft.Json.JsonConvert.DeserializeObject<List<DateTime>>(json);
            }

            if (history == null)
                history = new List<DateTime>();

            this.Pomodoros = new ObservableCollection<DateTime>(history);
        }
    }
}
