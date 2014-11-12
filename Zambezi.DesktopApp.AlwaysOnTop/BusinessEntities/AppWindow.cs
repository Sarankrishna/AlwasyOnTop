using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zambezi.DesktopApp.AlwaysOnTop.DataModel;

namespace Zambezi.DesktopApp.AlwaysOnTop.BusinessEntities
{
    public class AppWindow : DataModelBase
    {
        public IntPtr WindowHandle { get; set; }
        public string WindowTilte { get; set; }

        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }
    }
}
