using System.Drawing;

namespace CampusReportApp.UI
{
    public static class ThemeColor
    {
        // Professional Palette: Deep Blue & Vibrant Accent
        public static Color PrimaryColor = Color.FromArgb(44, 62, 80); // Dark Blue/Grey
        public static Color SecondaryColor = Color.FromArgb(52, 152, 219); // Bright Blue (Action)
        public static Color AccentColor = Color.FromArgb(231, 76, 60); // Red (Destructive)
        public static Color SuccessColor = Color.FromArgb(46, 204, 113); // Green (Success)
        public static Color BackgroundColor = Color.FromArgb(236, 240, 241); // Light Grey
        public static Color TextColor = Color.FromArgb(44, 62, 80);
        public static Color LightTextColor = Color.White;
        public static Color ButtonHoverColor = Color.FromArgb(41, 128, 185); // Darker Blue
        
        public static Font PrimaryFont = new Font("Segoe UI", 10F, FontStyle.Regular);
        public static Font HeaderFont = new Font("Segoe UI", 18F, FontStyle.Bold);
    }
}
