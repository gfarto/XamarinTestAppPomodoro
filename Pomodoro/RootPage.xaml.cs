using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pomodoro.ViewModels;
using Pomodoro.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pomodoro
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            InitializeComponent();
            //MasterPage.ListView.ItemSelected += ListView_ItemSelected;

            this.navigateSuscription("GoToPomodoro", new PomodoroPage());
            this.navigateSuscription("GoToConfiguration", new ConfigurationPage());
            this.navigateSuscription("GoToHistory", new HistoryPage());
        }

        private void navigateSuscription(string suscriptionID, Page page)
        {
            MessagingCenter.Subscribe<RootPageViewModel>(this, suscriptionID, (a) =>
            {
                this.Detail = new NavigationPage(page);
                this.IsPresented = false;
            });
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as RootPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            //MasterPage.ListView.SelectedItem = null;
        }
    }
}
