using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Zambezi.DesktopApp.AlwaysOnTop.BusinessEntities;

namespace Zambezi.DesktopApp.AlwaysOnTop.DataModel
{
    public class MainWindowDataModel : DataModelBase
    {

        private ObservableCollection<AppWindow> _appWindows;

        public ObservableCollection<AppWindow> AppWindows
        {
            get { return _appWindows; }
            set
            {
                _appWindows = value;
                OnPropertyChanged("AppWindows");
            }
        }

        private ICommand _makeAlwaysOnTopCommand;

        public ICommand MakeAlwaysOnTopCommand
        {
            get { return _makeAlwaysOnTopCommand; }
            set { _makeAlwaysOnTopCommand = value; }
        }

        private ICommand _makeUnTopCommand;

        public ICommand MakeUnTopCommand
        {
            get { return _makeUnTopCommand; }
            set { _makeUnTopCommand = value; }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get { return _closeCommand; }
            set { _closeCommand = value; }
        }

        private ICommand _markAllCommand;
                      
        public ICommand MarkAllCommand
        {
            get { return _markAllCommand; }
            set { _markAllCommand = value; }
        }

        private ICommand _unMarkAllCommand;
        public ICommand UnMarkAllCommand
        {
            get { return _unMarkAllCommand; }
            set { _unMarkAllCommand = value; }
        }
    }
}
