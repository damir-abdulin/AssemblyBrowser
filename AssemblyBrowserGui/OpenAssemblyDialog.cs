using System.Windows;
using Microsoft.Win32;

namespace AssemblyBrowserGui;

public class OpenAssemblyDialog
{
    public string FilePath { get; set; }
 
    public bool OpenFileDialog()
    {
        var openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() != true) return false;
        
        FilePath = openFileDialog.FileName;
        return true;
    }
    
    public void ShowMessage(string message)
    {
        MessageBox.Show(message);
    }
}