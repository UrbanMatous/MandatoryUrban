using System.Text.Json;

/// <summary>
/// Represents configuration data for the game framework.
/// </summary>
public class GameConfiguration
{

    /// <summary>
    /// The width of the game world.
    /// </summary>
    public int WorldWidth { get; set; }

    /// <summary>
    /// The height of the game world.
    /// </summary>
    public int WorldHeight { get; set; }

    /// <summary>
    /// The difficulty level of the game.
    /// </summary>
    public string GameLevel { get; set; }

    /// <summary>
    /// Loads configuration from a JSON file.
    /// </summary>

    public static GameConfiguration Load(string path = "C:\\Users\\matyu\\source\\repos\\GameFramework.Demo\\GameFramework.Demo\\config.json")
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<GameConfiguration>(json);
    }
}