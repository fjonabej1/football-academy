var service = new PlayerService();

service.AddPlayer(new Player
{
    Id = 1,
    Name = "Ardi",
    Age = 12,
    Group = "U13"
});

var players = service.GetPlayers();

foreach (var p in players)
{
    Console.WriteLine(p.Name);
}