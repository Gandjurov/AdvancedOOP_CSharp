using System;
using System.Collections.Generic;
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
}

