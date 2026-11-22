using System.Text.Json;
using MyHttpServer;

Settings settings = new Settings();
if (File.Exists("settings.json"))
{
    string settingsJson = File.ReadAllText("settings.json");
    settings = JsonSerializer.Deserialize<Settings>(settingsJson)
               ?? throw new Exception("Некорректный settings.json");
}


HttpServer server = new HttpServer(settings);
server.Start();
while (true)
{
    while (true)
    {
        string? command = Console.ReadLine();
        if (command == null) { Thread.Sleep(1000); continue; }
        if (command.Equals("shutdown")) { server.Stop(); break; }
    }
}