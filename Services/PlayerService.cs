public class PlayerService
{
    private readonly IRepository<Player> _repository;

    public PlayerService()
    {
        _repository = new FileRepository<Player>(
            "players.csv",
            Player.FromCsv
        );
    }

    public void AddPlayer(Player player)
    {
        _repository.Add(player);
        _repository.Save();
    }

    public List<Player> GetPlayers()
    {
        return _repository.GetAll();
    }
}