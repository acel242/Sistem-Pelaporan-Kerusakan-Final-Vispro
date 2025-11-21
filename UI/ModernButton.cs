using System;
using System.Drawing;
using System.Windows.Forms;

namespace CampusReportApp.UI
{
    public class ModernButton : Button
    {
        public ModernButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 45);
            this.BackColor = ThemeColor.SecondaryColor;
            this.ForeColor = ThemeColor.LightTextColor;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.Cursor = Cursors.Hand;
            this.TextAlign = ContentAlignment.MiddleCenter;
            
            this.MouseEnter += (s, e) => { 
                // Only darken if not explicitly set to another color (like Red for delete)
                if (this.BackColor == ThemeColor.SecondaryColor) 
                    this.BackColor = ThemeColor.ButtonHoverColor; 
            };
            this.MouseLeave += (s, e) => { 
                if (this.BackColor == ThemeColor.ButtonHoverColor) 
                    this.BackColor = ThemeColor.SecondaryColor; 
            };
        }
    }
}
