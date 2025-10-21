using System;
using System.Drawing;
using System.Windows.Forms;

internal static class UIhelper
{
    // ===== Center Label in Panel (Both Axes) =====
    public static void CenterLabelInPanel(Label lbl, Panel pnl)
    {
        if (lbl == null || pnl == null) return;
        lbl.Dock = DockStyle.None;
        lbl.Anchor = AnchorStyles.None;

        int x = (pnl.Width - lbl.Width) / 2;
        int y = (pnl.Height - lbl.Height) / 2;
        lbl.Location = new Point(x, y);

        pnl.Resize += (s, e) =>
        {
            lbl.Location = new Point((pnl.Width - lbl.Width) / 2, (pnl.Height - lbl.Height) / 2);
        };
    }

    // ===== Center Label Horizontally Only =====
    public static void CenterLabelInPanelHor(Label lbl, Panel pnl)
    {
        if (lbl == null || pnl == null) return;
        lbl.Dock = DockStyle.None;
        lbl.Anchor = AnchorStyles.None;

        int x = (pnl.Width - lbl.Width) / 2;
        lbl.Location = new Point(x, lbl.Location.Y);

        pnl.Resize += (s, e) =>
        {
            lbl.Location = new Point((pnl.Width - lbl.Width) / 2, lbl.Location.Y);
        };
    }

    // ===== Fit Label Text to Panel =====
    public static void FitTextToPanel(Label label, Panel panel)
    {
        if (string.IsNullOrEmpty(label.Text)) return;

        label.AutoSize = false;
        label.TextAlign = ContentAlignment.MiddleCenter;
        label.Dock = DockStyle.Fill;

        int maxWidth = panel.ClientSize.Width - 10;
        int maxHeight = panel.ClientSize.Height - 10;

        float fontSize = 20f;
        Font testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
        Size textSize = TextRenderer.MeasureText(label.Text, testFont, new Size(maxWidth, int.MaxValue),
            TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);

        while ((textSize.Width > maxWidth || textSize.Height > maxHeight) && fontSize > 6f)
        {
            fontSize -= 0.5f;
            testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
            textSize = TextRenderer.MeasureText(label.Text, testFont, new Size(maxWidth, int.MaxValue),
                TextFormatFlags.WordBreak | TextFormatFlags.TextBoxControl);
        }

        label.Font = testFont;
    }

    // ===== Center Label and TextBox as a Group =====
    public static void CenterLabelAndTextBox(Panel panel, Label lbl, TextBox txt)
    {
        if (panel == null || lbl == null || txt == null) return;

        int groupLeft = Math.Min(lbl.Left, txt.Left);
        int groupRight = Math.Max(lbl.Right, txt.Right);
        int groupTop = Math.Min(lbl.Top, txt.Top);
        int groupBottom = Math.Max(lbl.Bottom, txt.Bottom);

        int groupWidth = groupRight - groupLeft;
        int groupHeight = groupBottom - groupTop;

        int startX = (panel.ClientSize.Width - groupWidth) / 2;
        int startY = (panel.ClientSize.Height - groupHeight) / 2;

        int offsetX = startX - groupLeft;
        int offsetY = startY - groupTop;

        lbl.Left += offsetX;
        lbl.Top += offsetY;
        txt.Left += offsetX;
        txt.Top += offsetY;
    }

    // ===== Center Three Buttons Horizontally in Panel =====
    public static void CenterThreeButtons(Button btn1, Button btn2, Button btn3, Panel panel)
    {
        if (btn1 == null || btn2 == null || btn3 == null || panel == null) return;

        int spacing = 10;

        void RecenterButtons()
        {
            int totalWidth = btn1.Width + btn2.Width + btn3.Width + (2 * spacing);
            int availableWidth = panel.ClientSize.Width;
            int usedSpacing = spacing;

            if (totalWidth > availableWidth)
            {
                usedSpacing = Math.Max(2, (availableWidth - (btn1.Width + btn2.Width + btn3.Width)) / 2);
                totalWidth = btn1.Width + btn2.Width + btn3.Width + (2 * usedSpacing);
            }

            int startX = Math.Max((panel.ClientSize.Width - totalWidth) / 2, 0);
            int centerY = (panel.ClientSize.Height - btn1.Height) / 2;

            btn1.Left = startX;
            btn2.Left = startX + btn1.Width + usedSpacing;
            btn3.Left = startX + btn1.Width + btn2.Width + (2 * usedSpacing);
            btn1.Top = btn2.Top = btn3.Top = centerY;
        }

        RecenterButtons();
        panel.Resize += (s, e) => RecenterButtons();
    }

    // ===== Anchor Label and Control to Left and Vertically Center =====
    public static void AnchorLeftVertically(Panel panel, Label lbl, Control ctrl, int spacing = 5)
    {
        if (panel == null || lbl == null || ctrl == null) return;

        lbl.Anchor = AnchorStyles.Left;
        ctrl.Anchor = AnchorStyles.Left;

        lbl.Left = 10;
        lbl.Top = (panel.Height - lbl.Height) / 2;

        ctrl.Left = lbl.Right + spacing;
        ctrl.Top = (panel.Height - ctrl.Height) / 2;

        panel.Resize += (s, e) =>
        {
            lbl.Top = (panel.Height - lbl.Height) / 2;
            ctrl.Top = (panel.Height - ctrl.Height) / 2;
            ctrl.Left = lbl.Right + spacing;
        };
    }
}
