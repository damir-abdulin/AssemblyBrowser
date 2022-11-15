using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using AssemblyBrowserCore;
using NUnit.Framework;

namespace AssemblyBrowserTests;

public class IElementInfoTest
{
    private const string TestingAssemblyPath = @"assemblies/AssemblyBrowserTest.dll";
    
    private const string MethodSignature = "Int32 Add(Int32)";
    private const string MethodWithoutParamsSignature = "Void DoNothing()";
    private const string StaticMethodSignature = "Int32 Add(Int32, Int32)";
    private const string FieldFullName = "Int32 publicField";
    private const string PropertyFullName = "String Property";
    
    private readonly ObservableCollection<IElementInfo> _namespaces;
    
    private readonly IElementInfo? _methodAdd;
    private readonly IElementInfo? _methodWithoutParams;
    private readonly IElementInfo? _staticMethodAdd;
    private readonly IElementInfo? _field;
    private readonly IElementInfo? _property;
    
    public IElementInfoTest()
    {
        _namespaces = AssemblyLoader.GetNamespaces(TestingAssemblyPath);
        
        var namespaceA =
            _namespaces.First(el => el.Name == "AssemblyBrowserTest.A");
        var namespaceB =
            _namespaces.First(el => el.Name == "AssemblyBrowserTest.B");
        
        var typeA = namespaceA.Elements.First(el => el.Name == "A");
        var typeB = namespaceB.Elements.First(el => el.Name == "B");
        
        _methodAdd = 
            typeA.Elements.FirstOrDefault(el => el.Name == MethodSignature);
        _staticMethodAdd = 
            typeB.Elements.FirstOrDefault(el => el.Name == StaticMethodSignature);
        _methodWithoutParams =
            typeB.Elements.FirstOrDefault(el => el.Name == MethodWithoutParamsSignature);
        _field = 
            typeA.Elements.FirstOrDefault(el => el.Name == FieldFullName);
        _property = 
            typeA.Elements.FirstOrDefault(el => el.Name == PropertyFullName);
    }

    [Test]
    public void Elements_CountNamespaces_Return2()
    {
        Assert.IsTrue(_namespaces.Count == 4, $"Assembly has {_namespaces.Count} namespaces, but should contains 2");
    }
    
    [Test]
    public void Name_GetMethodFullName_ReturnSignature()
    {
        Assert.IsNotNull(_methodAdd, $"AssemblyInfo hasn't '{MethodSignature}'");
    }

    [Test]
    public void Name_GetStaticMethodFullName_ReturnSignature()
    {
        Assert.IsNotNull(_staticMethodAdd, $"AssemblyInfo hasn't '{StaticMethodSignature}'");
    }
    
    [Test]
    public void Name_GetMethodWithoutParamsFullName_ReturnSignature()
    {
        Assert.IsNotNull(_methodWithoutParams, $"AssemblyInfo hasn't '{MethodWithoutParamsSignature}'");
    }

    [Test]
    public void Name_GetPropertyFullName_ReturnTypeAndName()
    {
        Assert.IsNotNull(_property, $"AssemblyInfo hasn't '{PropertyFullName}'");
    }
    
    [Test]
    public void Name_GetFieldFullName_ReturnTypeAndName()
    {
        Assert.IsNotNull(_field, $"AssemblyInfo hasn't '{FieldFullName}'");
    }
}