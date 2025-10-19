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
}
