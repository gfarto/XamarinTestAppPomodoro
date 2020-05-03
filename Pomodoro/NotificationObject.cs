using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Pomodoro
{
    public abstract class NotificationObject : INotifyPropertyChanged
    {
        public NotificationObject()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
