using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class FileRepository<T> : IRepository<T>
{
    private readonly string _filePath;
    private readonly List<T> _data;
    private readonly Func<string, T> _fromCsv;

    public FileRepository(string filePath, Func<string, T> fromCsv)
    {
        _filePath = filePath;
        _fromCsv = fromCsv;
        _data = new List<T>();

        Load();
    }

    private void Load()
    {
        if (!File.Exists(_filePath))
            return;

        var lines = File.ReadAllLines(_filePath);

        foreach (var line in lines)
        {
            var item = _fromCsv(line);
            _data.Add(item);
        }
    }

    public List<T> GetAll()
    {
        return _data;
    }

    public T GetById(int id)
    {
        // kërkon property "Id"
        return _data.FirstOrDefault(x =>
        {
            var prop = x.GetType().GetProperty("Id");
            return (int)prop.GetValue(x) == id;
        });
    }

    public void Add(T entity)
    {
        _data.Add(entity);
    }

    public void Save()
    {
        var lines = _data.Select(x => x.ToString());
        File.WriteAllLines(_filePath, lines);
    }
}