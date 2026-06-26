using MySql.Data.MySqlClient;

namespace CyberSecurityAwarenessBot.Classes
{
    public class DatabaseManager
    {
        private string connectionString =
            "server=localhost;database=CyberBotDB;uid=root;pwd=Moganolucky@10;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}