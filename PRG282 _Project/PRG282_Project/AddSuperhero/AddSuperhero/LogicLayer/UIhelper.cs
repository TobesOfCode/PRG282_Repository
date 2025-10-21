using System;
using System.Drawing;
using System.Windows.Forms;

internal static class UIhelper
{
    public static void CenterLabelInPanel(Label lbl, Panel pnl)
    {
        if (lbl == null || pnl == null) return;

        // Ensure the label won't stretch or move due to docking or anchoring
        lbl.Dock = DockStyle.None;
        lbl.Anchor = AnchorStyles.None;

        // Calculate initial center position
        int x = (pnl.Width - lbl.Width) / 2;
        int y = (pnl.Height - lbl.Height) / 2;
        lbl.Location = new System.Drawing.Point(x, y);

        // Keep label centered if panel resizes
        pnl.Resize += (s, e) =>
        {
            lbl.Location = new System.Drawing.Point((pnl.Width - lbl.Width) / 2, (pnl.Height - lbl.Height) / 2);
        };
    }

    public static void CenterLabelInPanelHor(Label lbl, Panel pnl)
    {
        if (lbl == null || pnl == null) return;

        // Ensure the label won't stretch or move due to docking or anchoring
        lbl.Dock = DockStyle.None;
        lbl.Anchor = AnchorStyles.None;

        // Calculate initial horizontal center (keep current Y)
        int x = (pnl.Width - lbl.Width) / 2;
        lbl.Location = new System.Drawing.Point(x, lbl.Location.Y);

        // Keep label horizontally centered if panel resizes
        pnl.Resize += (s, e) =>
        {
            lbl.Location = new System.Drawing.Point((pnl.Width - lbl.Width) / 2, lbl.Location.Y);
        };
    }

    public static void FitTextToPanel(Label label, Panel panel)
    {
        if (string.IsNullOrEmpty(label.Text))
            return;

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
    public static void CenterLabelAndTextBox(Panel panel, Label lbl, TextBox txt)
    {
        if (panel == null || lbl == null || txt == null)
            return;

        // Calculate group bounds
        int groupLeft = Math.Min(lbl.Left, txt.Left);
        int groupRight = Math.Max(lbl.Right, txt.Right);
        int groupTop = Math.Min(lbl.Top, txt.Top);
        int groupBottom = Math.Max(lbl.Bottom, txt.Bottom);

        int groupWidth = groupRight - groupLeft;
        int groupHeight = groupBottom - groupTop;

        // Calculate new top-left coordinates to center the group
        int startX = (panel.ClientSize.Width - groupWidth) / 2;
        int startY = (panel.ClientSize.Height - groupHeight) / 2;

        // Offset to move both controls
        int offsetX = startX - groupLeft;
        int offsetY = startY - groupTop;

        // Move controls by the offset
        lbl.Left += offsetX;
        lbl.Top += offsetY;
        txt.Left += offsetX;
        txt.Top += offsetY;
    }

    public static void CenterThreeButtons(Button btn1, Button btn2, Button btn3, Panel panel)
    {
        if (btn1 == null || btn2 == null || btn3 == null || panel == null)
            return;

        // Calculate total width of all buttons including space between them
        int spacing = 10; // space between buttons
        int totalWidth = btn1.Width + btn2.Width + btn3.Width + 2 * spacing;

        // Calculate starting X to center the group
        int startX = (panel.ClientSize.Width - totalWidth) / 2;

        // Set positions
        btn1.Left = startX;
        btn2.Left = startX + btn1.Width + spacing;
        btn3.Left = startX + btn1.Width + btn2.Width + 2 * spacing;

        // Optional: vertically center in panel
        int centerY = (panel.ClientSize.Height - btn1.Height) / 2;
        btn1.Top = centerY;
        btn2.Top = centerY;
        btn3.Top = centerY;

        // Recenter on panel resize
        panel.Resize += (s, e) =>
        {
            int newStartX = (panel.ClientSize.Width - totalWidth) / 2;
            btn1.Left = newStartX;
            btn2.Left = newStartX + btn1.Width + spacing;
            btn3.Left = newStartX + btn1.Width + btn2.Width + 2 * spacing;
        };
    }

    public static void AnchorLeftVertically(Panel panel, Label lbl, Control ctrl, int spacing = 5)
    {
        if (panel == null || lbl == null || ctrl == null) return;

        // Anchor both controls to left
        lbl.Anchor = AnchorStyles.Left;
        ctrl.Anchor = AnchorStyles.Left;

        // Position initially
        lbl.Left = 10; // 10 px from panel left
        lbl.Top = (panel.Height - lbl.Height) / 2;

        ctrl.Left = lbl.Right + spacing;
        ctrl.Top = (panel.Height - ctrl.Height) / 2;

        // Keep vertically centered on panel resize
        panel.Resize += (s, e) =>
        {
            lbl.Top = (panel.Height - lbl.Height) / 2;
            ctrl.Top = (panel.Height - ctrl.Height) / 2;
            ctrl.Left = lbl.Right + spacing; // keep spacing constant
        };
    }
}
