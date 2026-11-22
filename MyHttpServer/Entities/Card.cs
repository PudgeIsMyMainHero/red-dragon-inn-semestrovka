namespace MyHttpServer.Entities;


public class Card
{
    public int Id { get; set; }
    public int CharacterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // Свойства карты из правил. У одной карты их может быть несколько сразу.
    public bool IsAction { get; set; }
    public bool IsSometimes { get; set; }
    public bool IsAlways { get; set; }
    public bool IsGamble { get; set; }
    public bool IsCheat { get; set; }

    // Сколько таких карт в колоде персонажа.
    public int Copies { get; set; } = 1;

    
    // Путь от static/cards/ NULL, если картинки нет.
    public string? ImagePath { get; set; }
}
