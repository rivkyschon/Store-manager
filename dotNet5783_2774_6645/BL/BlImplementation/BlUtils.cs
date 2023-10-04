using BlApi;
using System.Reflection;

namespace BlImplementation;

internal static class BlUtils
{
    internal static S cast<S, T>(T t) where S : new()
    {
        object s = new S();
        foreach (PropertyInfo prop in t?.GetType().GetProperties() ?? throw new BlNoPropertiesInObject())
        {
            PropertyInfo? type = s?.GetType().GetProperty(prop.Name);
            if (prop.Name == "Amount" && type == null&& s?.GetType().GetProperty("InStock")!=null)
            {
                s?.GetType().GetProperty("InStock").SetValue(s, t?.GetType()?.GetProperty(prop.Name)?.GetValue(t, null) );
                break;
            }
            if (type == null || type.Name == "Category")
                continue;
            var value = t?.GetType()?.GetProperty(prop.Name)?.GetValue(t, null);



            type.SetValue(s, value);
        }
        return (S)s;
    }
}

