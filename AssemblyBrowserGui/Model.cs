using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowserCore;

namespace AssemblyBrowserGui;

public class Model : INotifyPropertyChanged
{
    private ObservableCollection<IElementInfo> _namespaces;
    public ObservableCollection<IElementInfo> Namespaces
    {
        get => _namespaces;
        set
        {
            _namespaces = value;
            OnPropertyChanged("Elements");
        }
    }

    public Model()
    {
        _namespaces = AssemblyLoader.GetNamespaces(@"assemblies/AssemblyBrowserTest.dll");
    }

    public void UpdateNamespace(string assemblyPath)
    {
        _namespaces = AssemblyLoader.GetNamespaces(assemblyPath);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}