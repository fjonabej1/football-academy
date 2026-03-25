public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Group { get; set; }

    public override string ToString()
    {
        return $"{Id},{Name},{Age},{Group}";
    }

    public static Player FromCsv(string line)
    {
        var parts = line.Split(',');
        return new Player
        {
            Id = int.Parse(parts[0]),
            Name = parts[1],
            Age = int.Parse(parts[2]),
            Group = parts[3]
        };
    }
}