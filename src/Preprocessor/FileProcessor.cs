using System;
using System.IO;
using System.Linq;

public class FileProcessor
{
    string _originalsPath = null;
    string _convertedPath = null;
    string _filename =  null;
    RemovePeriodCommand _removePeriod = null;
    SingleCharTransform _singleCharTransform = null;
    NumberTransform _numberTransform = null;
    IdWithNumberTransform _idWithNumberTransform = null;
    ReplaceUrlTransform _replaceUrlTransform = null;



    public FileProcessor(string origPath, string convPath, string tokenString, string filename)
    {
        _originalsPath = origPath;
        _convertedPath = convPath;
        _singleCharTransform = new SingleCharTransform();
        _numberTransform = new NumberTransform();
        _removePeriod = new RemovePeriodCommand(tokenString);
        _idWithNumberTransform = new IdWithNumberTransform();
        _replaceUrlTransform = new ReplaceUrlTransform();
        _filename = filename;
    }

    public void Process()
    {
        var files = Directory.GetFiles(_originalsPath);
        if(!string.IsNullOrWhiteSpace(_filename)){
            files = files.Where(f=>f.Contains(_filename)).ToArray();
        }
        foreach(var f in files)
        {
            Console.WriteLine($"Processing File: {f}");
            var filename = Path.GetFileName(f);
            var output = File.ReadAllText(f);
            output = output.Replace(System.Environment.NewLine," ");
            output = _replaceUrlTransform.Execute(output);
            output = _idWithNumberTransform.Execute(output);
            output = _numberTransform.Execute(output);
            output = _singleCharTransform.Execute(output);
            output = _removePeriod.Execute(output);
            output = handleExceptions(output);
            File.WriteAllText(Path.Combine(_convertedPath,filename), output);
        }
    }

    private string handleExceptions(string data){
        var output = data;
        output = output.Replace("e.g.", "eg");
        output = output.Replace("e.g .", "eg");
        output = output.Replace("e.g", "eg");
        return output;
    }
}