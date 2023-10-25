
namespace Math4Saimmod.Lib.Random
{
    public class Random
    {
        private readonly int a;
        private readonly int m;
        private double r;
        public double[] random;

        public static int N = 150000;
        public double ExpVal;
        public double StaDev;
        public double Disper;
        public double K;
        public int P;
        public int Aperiod;


        public Random(int a, int r, int m)
        {
            this.a = a;
            this.r = r;
            this.m = m;
            random = new double[N];
        }

        public double[] GetRandom()
        {
            double curR;
            for (int i = 0; i < random.Length; i++)
            {
                curR = (a * r) % m;
                r = curR;
                random[i] = curR / m;
            }

            return random;
        }
    }
}
