
namespace Math4Saimmod.Lib.LemRandom
{
    public static class Distribution
    {
        public static float ExponentialDistribution(float rand, double λ)
        {
            return (float)(-Math.Log(rand) / λ); 
        }
    }
}
