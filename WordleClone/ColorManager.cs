using System;
using Xamarin.Forms;
namespace WordleClone
{
    public class ColorManager
    {
        public static Color KeyboardTextColor(bool set)
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            if (set)
            {
                return Color.White;
            }
            else
            {
                if (currentTheme == OSAppTheme.Light) return Color.Black;
                return Color.White;
            }
        }

        public static Color FrameBackgroundColor(int selection)
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            switch (selection)
            {
                case 0: // Unclicked option
                    if (currentTheme == OSAppTheme.Light)
                        return Color.FromRgb(r: 212, g: 214, b: 218);
                    return Color.FromRgb(r: 129, g: 131, b: 132);
                case 1: // Clicked but wrong
                    if (currentTheme == OSAppTheme.Light)
                        return Color.FromRgb(r: 121, g: 124, b: 126);
                    return Color.FromRgb(r: 58, g: 58, b: 60);
                case 2: // Wrong spot
                    if (currentTheme == OSAppTheme.Light)
                        return Color.FromRgb(r: 197, g: 181, b: 102);
                    return Color.FromRgb(r: 177, g: 160, b: 78);
                case 3: // Correct Spot
                    if (currentTheme == OSAppTheme.Light)
                        return Color.FromRgb(r: 122, g: 168, b: 107);
                    return Color.FromRgb(r: 97, g: 140, b: 85);
                default:
                    return Color.Magenta;
            }
        }

        public static int ReverseColorSearch(Color color)
        {
            if (color == Color.FromRgb(r: 212, g: 214, b: 218) || color == Color.FromRgb(r: 129, g: 131, b: 132))
            {
                return 0;
            }

            if (color == Color.FromRgb(r: 121, g: 124, b: 126) || color == Color.FromRgb(r: 58, g: 58, b: 60))
            {
                return 1;
            }

            if (color == Color.FromRgb(r: 197, g: 181, b: 102) || color == Color.FromRgb(r: 177, g: 160, b: 78))
            {
                return 2;
            }

            if (color == Color.FromRgb(r: 122, g: 168, b: 107) || color == Color.FromRgb(r: 97, g: 140, b: 85))
            {
                return 3;
            }

            return -1;
        }

        public static bool IsLightMode()
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            return currentTheme == OSAppTheme.Light;
        }
    }
}
