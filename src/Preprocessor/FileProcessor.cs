using System;
using System.IO;

public class FileProcessor
{
    string _originalsPath = null;
    string _convertedPath = null;
    RemovePeriodCommand _removePeriod = null;
    SingleCharTransform _singleCharTransform = null;
    NumberTransform _numberTransform = null;


    public FileProcessor(string origPath, string convPath, string tokenString)
    {
        _originalsPath = origPath;
        _convertedPath = convPath;
        _singleCharTransform = new SingleCharTransform();
        _numberTransform = new NumberTransform();
        _removePeriod = new RemovePeriodCommand(tokenString);
    }

    public void Process()
    {
        var files = Directory.GetFiles(_originalsPath);
        foreach(var f in files)
        {
            Console.WriteLine($"Processing File: {f}");
            var filename = Path.GetFileName(f);
            var input = File.ReadAllText(f);
            var output = _removePeriod.Execute(input);
            output = _numberTransform.Execute(output);
            output = _singleCharTransform.Execute(output);
            File.WriteAllText(Path.Combine(_convertedPath,filename), output);
        }
    }
}