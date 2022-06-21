using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adita.Windows.Converters.Sample.Viewmodels
{
    [INotifyPropertyChanged]
    public partial class MainViewModel
    {
        #region Private fields
        [ObservableProperty]
        private double doubleValue = 200;
        #endregion Private fields
    }
}
