using Math4Saimmod.Lib.Elements;

namespace Math4Saimmod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tbRun_Click(object sender, EventArgs e)
        {
            int n = Int32.Parse(tbTicks.Text);
            double p1 = Double.Parse(tbP1.Text);
            double p2 = Double.Parse(tbP2.Text);
            Model model = new Model((float)p1, (float)p2);
            model.Run(n);
            float loch = (float)model.queue.ticksInQueue / n;
            float lc = loch + 0.8f;
            float woch = loch * 10;
            float wc = lc * 10;

            lbLoch.Text = $"Loch: {loch}";
            lbLc.Text = $"Lc: {lc}";
            lbWoch.Text = $"Woch: {woch}";
            lbWc.Text = $"Wc: {wc}";
        }
    }
}