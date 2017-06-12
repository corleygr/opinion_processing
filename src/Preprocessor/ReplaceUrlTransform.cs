using System;
using System.Collections;
using System.Text.RegularExpressions;


public class ReplaceUrlTransform:ICommand 
{
   private string _pattern = @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)";

    public string Execute(string data){
        var rgx = new Regex(_pattern);
        var output = rgx.Replace(data,"website");
        return output;
    }
}