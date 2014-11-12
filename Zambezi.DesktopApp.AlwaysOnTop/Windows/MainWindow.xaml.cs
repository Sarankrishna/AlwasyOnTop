using System.Windows;
using Zambezi.DesktopApp.AlwaysOnTop.Presenter;

namespace Zambezi.DesktopApp.AlwaysOnTop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowPresenter _presenter = new MainWindowPresenter();
        public MainWindow()
        {
            InitializeComponent();
            _presenter.LoadData();
            _presenter.View = this;
            this.DataContext = _presenter.DataModel;
        }

    

    }
}
