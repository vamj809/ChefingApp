using PropertyChanged;
using System.ComponentModel;

namespace ChefingApp.ViewModels
{
    [SuppressPropertyChangedWarnings]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
