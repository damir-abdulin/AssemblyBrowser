using System.Collections.ObjectModel;

namespace AssemblyBrowserCore.Elements;

public class TypeInfo : IElementInfo
{
    public string Name { get; }
    public ObservableCollection<IElementInfo> Elements { get; }

    private readonly Type _type;

    public TypeInfo(Type type)
    {
        _type = type;
        
        Name = type.Name;
        Elements = new ObservableCollection<IElementInfo>();

        GetFields();
        GetProperties();
        GetMethods();
    }

    private void GetFields()
    {
        var fieldsInfo = _type.GetFields();

        foreach (var field in fieldsInfo)
        {
            Elements.Add(new FieldInfo(field));
        }
    }

    private void GetProperties()
    {
        var propertiesInfo = _type.GetProperties();

        foreach (var property in propertiesInfo)
        {
            Elements.Add(new PropertyInfo(property));
        }
    }
    
    private void GetMethods()
    {
        var methodsInfo = _type.GetMethods();

        foreach (var methodInfo in methodsInfo)
        {
            Elements.Add(new MethodInfo(methodInfo));
        }
    }
}