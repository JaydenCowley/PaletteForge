namespace PaletteForge.Models;

public record Rgb(int R, int G, int B)
{
    public string ToHex() => $"#{R:X2}{G:X2}{B:X2}";
}

public record Hsl(double H, double S, double L);