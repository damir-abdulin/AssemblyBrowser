using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AssemblyBrowserCore;

namespace AssemblyBrowserGui;

public class ApplicationViewModel : INotifyPropertyChanged
{
    private Model _model;
    private ObservableCollection<IElementInfo> _namespaces;
    private OpenAssemblyDialog _openAssemblyDialog;
    
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
                try
                {
                    if (!_openAssemblyDialog.OpenFileDialog()) return;
                    
                    _model.UpdateNamespace(_openAssemblyDialog.FilePath);
                    Namespaces = _model.Namespaces;
                }
                catch (Exception ex)
                {
                    _openAssemblyDialog.ShowMessage(ex.Message);
                }
                
            });
        }
    }

    public ApplicationViewModel()
    {
        _model = new Model();
        _openAssemblyDialog = new OpenAssemblyDialog();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}