using System.Runtime.InteropServices;
using System.Security.Claims;
using PaletteForge.Models;

namespace PaletteForge.Services;

public static class ColorUtils
{
    public static class ColorUtils
    {
        // Hex = #RRGGBB
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
    public static Rgb ParseRgbCsv(string rgb)
    {
        var parts = rgb.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        if (parts.Length != 3) throw new ArgumentException("RGB must be R,G,B");
        int r = int.Parse(parts[0]); int g = int.Parse(parts[1]); int b = int.Parse(parts[2]);
        return new Rgb(Clamp(r), Clamp(g), Clamp(b));
    }

    // HSL = Hue, Saturation, Lightness

    public static RgbToHsl(Rgb c)
    {
        double r = c.R / 255.0;
        double g = c.G / 255.0;
        double b = c.B / 255.0;
        double max = Math.Max(r, Math.Max(g, b));
        double min = Math.Min(r, Math.Min(g, b));
        double h, s, l = (max + min) / 2.0;
        // Calculate H and S if the difference is within 1e-9 or .000000001 between max and min to avoid floating point precision issues
        if (Math.Abs(max - min) < 1e-9) {h = 0; s = 0;}
        else
        {
            double delta = max - min;
            s = l > 0.5 ? delta / (2.0 - max - min) : delta / (max + min);
            if (Math.Abs(max - r) < 1e-9) h = (g - b) / delta + (g < b ? 6 : 0);
            else if (Math.Abs(max - g) < 1e-9) h = (b - r) / delta + 2;
            else h = (r - g) / delta + 4;
            h /= 6.0;
        }
        return new Hsl(NormHue(h), Math.Clamp(s, 0, 1), Math.Clamp(l, 0, 1));
    }
    public static HslToRgb(Hsl hsl)
    {
        double h = hsl.H / 360.0;
        double s = hsl.S;
        double l = hsl.L;
        if (s == 0){r = g = b = 1; }
        else
        {
            double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
            double p = 2 * l - q;
            r = HueToRgb(p, q, h + 1.0 / 3.0);
            g = HueToRgb(p, q, h);
            b = HueToRgb(p, q, h - 1.0 / 3.0);
        }
        return new Rgb((int)Math.Round(r * 255), (int)Math.Round(g * 255), (int)Math.Round(b * 255));
    }
    // Helper for HSL to RGB conversion
    private static double HueToRgb(double p, double q, double t)
    {
        if (t < 0) t += 1; if (t > 1) t -= 1;
        if (t < 1.0 / 6.0) return p + (q - p) * 6 * t;
        if (t < 1.0 / 2.0) return q;
        if (t < 2.0 / 3.0) return p + (q - p) * (2.0 / 3.0 - t) * 6;
        return p;
    }

        public static NormHue(double h) => (h % 360 + 360) % 360;
        public static int Clamp(int v) => Math.Max(0, Math.Min(255, v));
}