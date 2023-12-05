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
            double p3 = p1 / p2;
            double v = (double)1 / 3 + 1;
            Model model = new Model((float)p1, (float)p2);
            ModelIntensity modelI = new ModelIntensity(p1, p2);
            modelI.Run(n);
            //double loch = (p3 * p3 * v) / (2 * ( 1- p3));
            //double lc = (p3 * p3 * v) / (2 * (1 - p3)) + p3;
            //double woch = (p3 * p3 * v) / (2 * p1 * (1 - p3));
            //double wc = (p3 * p3 * v) / (2 * p1 * (1 - p3)) + 1 / p2;
            /*float loch = (float)model.processor1.queueTicks / n;
            float lc = (float)(model.processor1.queueTicks + model.processor1._tickCount) / (float)n;
            float woch = model.processor1._timeInQueue / n;
            float wc = (model.processor1._time + model.processor1._timeInQueue) / n;*/
            double loch = modelI.averageRequestsInQueue;
            double lc = modelI.averageRequestsInSystem;
            double woch = modelI.averageTimeInQueue;
            double wc = modelI.averageTimeInSystem;

            lbLoch.Text = $"Loch: {loch}";
            lbLc.Text = $"Lc: {lc}";
            lbWoch.Text = $"Woch: {woch}";
            lbWc.Text = $"Wc: {wc}";
        }
    }
}