using Math4Saimmod.Lib.LemRandom;

namespace Math4Saimmod.Lib.Elements
{
    internal class ModelIntensity
    {
        private double serviceRate;
        private double lambda;
        public double averageRequestsInSystem;
        public double averageRequestsInQueue;
        public double averageTimeInSystem;
        public double averageTimeInQueue;

        public ModelIntensity(double lambda, double mu)
        {
            this.lambda = lambda;
            this.serviceRate = mu;
        }

        public void Run(int Tacts)
        {
            double[] Arrivals = new double[Tacts];
            double[] ProcessingEnds = new double[Tacts];
            double[] ProcessingTimes = new double[Tacts];
            Random rand = new Random();
            double currentTime = 0;
            double totalWaitingTime = 0;
            double totalSystemTime = 0;

            for (int i = 0; i < Tacts; i++)
            {
                double interArrivalTime = Distribution.ExponentialDistribution(rand.NextSingle(), lambda);
                currentTime += interArrivalTime;
                Arrivals[i] = currentTime;
            }
            double serviceTime = GenerateErlang3ServiceTime();
            ProcessingTimes[0] = serviceTime;
            ProcessingEnds[0] = Arrivals[0] + serviceTime;
            for (int i = 1; i < Tacts; i++)
            {
                serviceTime = GenerateErlang3ServiceTime();
                ProcessingTimes[i] = serviceTime;
                totalSystemTime += serviceTime;
                if (serviceTime + Arrivals[i - 1] < Arrivals[i])
                {
                    ProcessingEnds[i] = Arrivals[i] + serviceTime;
                }
                else
                {
                    ProcessingEnds[i] = ProcessingEnds[i - 1] + serviceTime;
                }
            }

            for (int i = 0; i < Tacts; i++)
            {
                if (Arrivals[i] + ProcessingTimes[i] - ProcessingEnds[i] > 0.1)
                {
                    totalWaitingTime += Arrivals[i] + ProcessingTimes[i] - ProcessingEnds[i];
                }
            }

            averageRequestsInSystem = (totalSystemTime + totalWaitingTime) / ProcessingEnds[Tacts - 1];
            averageRequestsInQueue = totalWaitingTime / ProcessingEnds[Tacts - 1];
            averageTimeInSystem = (totalSystemTime + totalWaitingTime) / Tacts;
            averageTimeInQueue = totalWaitingTime / Tacts;
        }

        private double GenerateErlang3ServiceTime()
        {
            Random rand = new Random();

            double x1 = Distribution.ExponentialDistribution(rand.NextSingle(), serviceRate);
            double x2 = Distribution.ExponentialDistribution(rand.NextSingle(), serviceRate);
            double x3 = Distribution.ExponentialDistribution(rand.NextSingle(), serviceRate);

            return x1 + x2 + x3;
        }

    }
}
