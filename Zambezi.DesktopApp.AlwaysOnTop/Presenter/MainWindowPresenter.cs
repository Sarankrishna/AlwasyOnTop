using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using Zambezi.DesktopApp.AlwaysOnTop.Classes;
using Zambezi.DesktopApp.AlwaysOnTop.DataModel;
using Zambezi.DesktopApp.AlwaysOnTop.Windows;

namespace Zambezi.DesktopApp.AlwaysOnTop.Presenter
{
    public class MainWindowPresenter
    {
        private MainWindowDataModel _dataModel;
        private MainWindow _view;

        public MainWindow View
        {
            get { return _view; }
            set { _view = value; }
        }
        public MainWindowDataModel DataModel
        {
            get { return _dataModel; }
            set { _dataModel = value; }
        }

        public MainWindowPresenter()
        {
            _dataModel = new MainWindowDataModel();
            _dataModel.MakeAlwaysOnTopCommand = new DelegateCommand(MakeAlwaysOnTopCommandExecuted, MakeAlwaysOnTopCommandCanExcute);
            _dataModel.MakeUnTopCommand = new DelegateCommand(MakeUnTopCommandCommandExecuted, MakeUnTopCommandCanExcute);
            _dataModel.CloseCommand = new DelegateCommand(CloseCommandExecuted, CloseCommandCanExcute);
            _dataModel.MarkAllCommand = new DelegateCommand(MarkAllCommandExecuted, MarkAllCommandCanExcute);
            _dataModel.UnMarkAllCommand = new DelegateCommand(UnMarkAllCommandExecuted, UnMarkAllCommandCanExcute);

        }

        private bool UnMarkAllCommandCanExcute(object obj)
        {
            return _dataModel != null && _dataModel.AppWindows != null && _dataModel.AppWindows.Count > 0;;
        }

        private void UnMarkAllCommandExecuted(object obj)
        {
            MarkUnMarkAll(false);
        }

        private bool MarkAllCommandCanExcute(object obj)
        {
            return _dataModel != null && _dataModel.AppWindows != null && _dataModel.AppWindows.Count > 0;
        }

        private void MarkAllCommandExecuted(object obj)
        {
            MarkUnMarkAll(true);
        }

        private bool CloseCommandCanExcute(object obj)
        {
            return true;
        }

        private void CloseCommandExecuted(object obj)
        {
            if (View != null)
            {
                View.Close();
            }
        }

        private void MakeUnTopCommandCommandExecuted(object obj)
        {
            MakeWindowsTopOrNonTop(false);
        }

        private bool MakeUnTopCommandCanExcute(object obj)
        {
            return _dataModel != null && _dataModel.AppWindows != null && _dataModel.AppWindows.Count(a => a.Selected) > 0;
        }

        private void MakeAlwaysOnTopCommandExecuted(object obj)
        {
            MakeWindowsTopOrNonTop(true);
        }

        private bool MakeAlwaysOnTopCommandCanExcute(object obj)
        {
            return _dataModel != null && _dataModel.AppWindows != null && _dataModel.AppWindows.Count(a => a.Selected) > 0;
        }

        public void LoadData()
        {
            _dataModel.AppWindows =new System.Collections.ObjectModel.ObservableCollection<BusinessEntities.AppWindow>( WindowHelper.GetOpenAppWindows());
        }


        private void MakeWindowsTopOrNonTop(bool makeTopmost)
        {
            if (_dataModel != null && _dataModel.AppWindows != null && _dataModel.AppWindows.Count(a => a.Selected) > 0)
            {
                foreach (var appWindow in _dataModel.AppWindows.Where(a => a.Selected))
                {
                    Console.WriteLine("{0}: {1}", appWindow.WindowHandle, appWindow.WindowTilte);

                    RECT rect = new RECT();
                    WindowHelper.GetWindowRect(new HandleRef(this, appWindow.WindowHandle), out rect);

                    WindowHelper.SetWindowPos(appWindow.WindowHandle, makeTopmost ? WindowHelper.HWND_TOPMOST : WindowHelper.HWND_NOTOPMOST,
                                                rect.X, rect.Y, rect.Width, rect.Height, WindowHelper.SWP_SHOWWINDOW);
                }
             
            }
            else
            {
                MessageBox.Show("No windows are selected","AlwaysOnTop");
            }
        }

        private void MarkUnMarkAll(bool markAll)
        {
            foreach (var appWindow in _dataModel.AppWindows)
            {
                appWindow.Selected = markAll;
            }
        }
    }
}
