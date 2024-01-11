using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phase1Project1
{
    public class Player
    {
        public string PlayerName { get; set; }
        public int PlayerId { get; set; }
        public int PlayerAge { get; set; }
    }

    public interface ITeam
    {
        void Add(Player player);
        void Remove(int playerId);
        Player GetPlayerById(int playerId);
        Player GetPlayerByName(string playerName);
        List<Player> GetAllPlayers();
    }

    public class OneDayTeam : ITeam
    {
        public static List<Player> oneDayTeam = new List<Player>();

        public OneDayTeam()
        {
            // Set the capacity property to 11
            oneDayTeam.Capacity = 11;
        }

        public void Add(Player player)
        {
            // Implement functionality for adding a player to the Team
            if (oneDayTeam.Count < 11)
            {
                oneDayTeam.Add(player);
                Console.WriteLine("Player is added successfully");
            }
            else
            {
                Console.WriteLine("Cannot add more than 11 players to the team");
            }
        }

        public void Remove(int playerId)
        {
            // Implement functionality for removing a player from the Team by Player Id
            Player playerToRemove = oneDayTeam.Find(p => p.PlayerId == playerId);
            if (playerToRemove != null)
            {
                oneDayTeam.Remove(playerToRemove);
                Console.WriteLine("Player removed successfully");
            }
            else
            {
                Console.WriteLine("Player not found");
            }
        }

        public Player GetPlayerById(int playerId)
        {
            return oneDayTeam.Find(p => p.PlayerId == playerId);
        }

        public Player GetPlayerByName(string playerName)
        {
            return oneDayTeam.Find(p => p.PlayerName == playerName);
        }

        public List<Player> GetAllPlayers()
        {
            // Implement functionality to get all players from the Team
            return oneDayTeam;
        }
    }

  public   class Program
    {
        static void Main(string[] args)
        {
            OneDayTeam team = new OneDayTeam();

            // Implement the menu and switch-case construct as described in the prompt
            string choice;
            do
            {
                Console.WriteLine("Enter 1: To Add Player 2: To Remove Player by Id 3: Get Player By Id 4: Get Player by Name 5: Get All Players");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        // Code to add player
                        Console.WriteLine("Enter Player Id:");
                        int playerId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Player Name:");
                        string playerName = Console.ReadLine();
                        Console.WriteLine("Enter Player Age:");
                        int playerAge = Convert.ToInt32(Console.ReadLine());
                        Player newPlayer = new Player { PlayerId = playerId, PlayerName = playerName, PlayerAge = playerAge };
                        team.Add(newPlayer);
                        break;

                    case 2:
                        // Code to remove player by Id
                        Console.WriteLine("Enter Player Id to remove:");
                        int removePlayerId = Convert.ToInt32(Console.ReadLine());
                        team.Remove(removePlayerId);
                        break;

                    case 3:
                        // Code to get player by Id
                        Console.WriteLine("Enter Player Id:");
                        int getPlayerById = Convert.ToInt32(Console.ReadLine());
                        Player playerById = team.GetPlayerById(getPlayerById);
                        Console.WriteLine($"Player: {playerById.PlayerName}, Age: {playerById.PlayerAge}");
                        break;

                    case 4:
                        // Code to get player by Name
                        Console.WriteLine("Enter Player Name:");
                        string getPlayerByName = Console.ReadLine();
                        Player playerByName = team.GetPlayerByName(getPlayerByName);
                        Console.WriteLine($"Player: {playerByName.PlayerName}, Age: {playerByName.PlayerAge}");
                        break;

                    case 5:
                        // Code to get all players
                        List<Player> allPlayers = team.GetAllPlayers();
                        foreach (var player in allPlayers)
                        {
                            Console.WriteLine($"Player: {player.PlayerName}, Age: {player.PlayerAge}");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }

                Console.WriteLine("Do you want to continue (yes/no)?:");
                choice = Console.ReadLine();

            } while (choice.ToLower() == "yes");
        }
    }
}

