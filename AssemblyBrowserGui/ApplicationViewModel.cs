using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowserCore;

namespace AssemblyBrowserGui;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private Model _model;
    public ObservableCollection<IElementInfo> Namespaces { get; set; }


    public ApplicationViewModel()
    {
        _model = new Model();
        Namespaces = _model.Namespaces;
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}