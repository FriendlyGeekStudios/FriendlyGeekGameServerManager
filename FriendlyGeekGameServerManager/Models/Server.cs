namespace FriendlyGeekGameServerManager.Models
{
    public class Server
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ServerStatus Status { get; set; }
        public string? GamePort { get; set; }
        public string? QueryPort { get; set; }
    }
}
