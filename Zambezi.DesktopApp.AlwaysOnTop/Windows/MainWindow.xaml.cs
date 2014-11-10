using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zambezi.DesktopApp.AlwaysOnTop.Classes;
using System.Runtime.InteropServices;

namespace Zambezi.DesktopApp.AlwaysOnTop.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<IntPtr, string> lWindow in WindowHelper.GetOpenWindows())
            {
                IntPtr lHandle = lWindow.Key;
                string lTitle = lWindow.Value;

                Console.WriteLine("{0}: {1}", lHandle, lTitle);

                RECT rect = new RECT();
                WindowHelper.GetWindowRect(new HandleRef(this, lHandle), out rect);
                bool makeTopmost = false;
                WindowHelper.SetWindowPos(lHandle,
             makeTopmost ? WindowHelper.HWND_TOPMOST : WindowHelper.HWND_NOTOPMOST,
             rect.X, rect.Y, rect.Width, rect.Height,
             WindowHelper.SWP_SHOWWINDOW);
            }
        }
    }
}
