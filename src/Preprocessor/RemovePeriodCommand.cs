using System;
using System.Collections;
using System.Collections.Generic;

public class RemovePeriodCommand:ICommand 
{
    private Dictionary<string,string> _transforms = new Dictionary<string,string>();

    public RemovePeriodCommand(string tokenString)
    {
       var tokens = tokenString.Split('|');
       foreach(var t in tokens)
       {
           _transforms[$" {t}."] = $" {t}";
       }
    }

    public string Execute(string data)
    {
        var output = data;
        foreach(var key in _transforms.Keys)
        {
            output = output.Replace(key,_transforms[key]);
        }
        return output;
    }
}