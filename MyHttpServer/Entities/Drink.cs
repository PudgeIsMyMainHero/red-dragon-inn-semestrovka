namespace MyHttpServer.Entities;

public class Drink
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    // true для попойки, false для обычной выпивки.
    public bool IsBinge { get; set; }

    // Крепость: на сколько повышается опьянение. Бывает отрицательной.
    public int Strength { get; set; }

    // запивон: раскрывается ещё одна карта выпивки
    public bool HasChaser { get; set; }

    // Изменение стойкости. 0, если его нет
    public int FortitudeChange { get; set; }

    public int Copies { get; set; } = 1;

    // Путь от static/drinks/ NULL, пока картинки нет
    public string? ImagePath { get; set; }
}
