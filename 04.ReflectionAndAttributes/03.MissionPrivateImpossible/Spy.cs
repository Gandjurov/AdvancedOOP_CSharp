using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string className, params string[] inputFields)
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        var type = Type.GetType(className);

        var hackerInstance = Activator.CreateInstance(type);

        for (int i = 0; i < inputFields.Length; i++)
        {
            var currentField = type.GetField(inputFields[i], 
                BindingFlags.Public | 
                BindingFlags.Instance | 
                BindingFlags.NonPublic | 
                BindingFlags.Static);

            var value = currentField.GetValue(hackerInstance);

            sb.AppendLine($"{currentField.Name} = {value}");
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        Type classType = Type.GetType(investigatedClass);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var type = Type.GetType(className);

        var hackerInstance = Activator.CreateInstance(type);

        var allFields = type.GetFields((BindingFlags)62);

        var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => x.Name.StartsWith("get"));
        var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(x => x.Name.StartsWith("set"));


        foreach (var field in allFields)
        {
            if (field.IsPublic)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        foreach (var methodPrivate in privateMethods)
        {
            sb.AppendLine($"{methodPrivate.Name} have to be public!");
        }

        foreach (var methodPublic in publicMethods)
        {
            sb.AppendLine($"{methodPublic.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }
}



