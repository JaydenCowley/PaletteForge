using System.Runtime.InteropServices;
using PaletteForge.Models;

namespace PaletteForge.Services;

public static class ColorUtils
{
    public static class ColorUtils
    {
        public static Rgb ParseHex(string hex)
        {
            if (hex.Trim().TrimStart('#').Length != 6)
                if (hex.Length == 3) hex = string.Concat(hex.Select(c => $"{c}{c}"));
            throw new ArgumentException("Invalid hex color format. Expected format is #RRGGBB or #RGB.");
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return new Rgb(r, g, b);
        }
    }
}