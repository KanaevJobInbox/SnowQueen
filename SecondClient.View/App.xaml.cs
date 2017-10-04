using System.Windows;
using Client.ViewModel;

namespace SecondClient.View
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            MainWindowViewModel viewMain = new MainWindowViewModel();

            MainWindow main = new MainWindow();
            main.DataContext = viewMain;
            main.Show();
        }
    }
}
