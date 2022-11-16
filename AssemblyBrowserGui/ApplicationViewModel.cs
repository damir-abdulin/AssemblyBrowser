using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowserCore;

namespace AssemblyBrowserGui;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private Model _model;
    private ObservableCollection<IElementInfo> _namespaces;
    
    public ObservableCollection<IElementInfo> Namespaces
    {
        get => _namespaces;
        set
        {
            _namespaces = value;
            OnPropertyChanged("Namespaces");
        }
    }
    
    private RelayCommand? _loadNewAssemblyCommand;
    public RelayCommand LoadNewAssemblyCommand
    {
        get
        {
            return _loadNewAssemblyCommand ??= new RelayCommand(obj =>
            {
                _model.UpdateNamespace(@"C:\Users\damir\RiderProjects\Faker\FakerCore\bin\Debug\net6.0\FakerCore.dll");
                Namespaces = _model.Namespaces;
            });
        }
    }
    
    public ApplicationViewModel()
    {
        _model = new Model();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}