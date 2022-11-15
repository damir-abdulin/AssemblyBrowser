using System.Collections.ObjectModel;

namespace AssemblyBrowserCore.Elements;

internal class NamespaceInfo : IElementInfo
{
    public string Name { get; }
    public ObservableCollection<IElementInfo> Elements { get; }

    public NamespaceInfo(string name)
    {
        Name = name;
        Elements = new ObservableCollection<IElementInfo>();
    }
    
    public void AddType(Type type)
    {
        Elements.Add(new TypeInfo(type));
    }
}