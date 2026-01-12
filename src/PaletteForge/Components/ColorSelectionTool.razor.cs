using Microsoft.AspNetCore.Components;

namespace PaletteForge.Components
{
    public partial class ColorSelectionTool
    {
        [Parameter]
        public EventCallback<int> OnThemeDarknessChanged { get; set; }

        [Parameter]
        public EventCallback<string> OnColorChanged { get; set; }
        public string ColorValue { get; set; } = "#ffffff";
    }
}