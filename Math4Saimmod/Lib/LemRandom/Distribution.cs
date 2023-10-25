
namespace Math4Saimmod.Lib.LemRandom
{
    public static class Distribution
    {
        public static double[] ExponentialDistribution(double[] rand, int N, double λ)
        {
            double[] result = new double[N];
            for (int i = 0; i < N; i++)
                result[i] = -Math.Log(rand[i]) / λ;
            return result;
        }
    }
}
