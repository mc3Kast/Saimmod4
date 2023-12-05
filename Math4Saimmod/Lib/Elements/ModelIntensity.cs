using Math4Saimmod.Lib.LemRandom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math4Saimmod.Lib.Elements
{
    internal class ModelIntensity
    {
        private Queue<double> arrivalTimes = new Queue<double>();
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

        public void Run(int numberOfRequests)
        {
            double[] Arrivals = new double[numberOfRequests];
            double[] Processing = new double[numberOfRequests];
            Random rand = new Random();
            double currentTime = 0;
            double totalWaitingTime = 0;
            double totalSystemTime = 0;

            for (int i = 0; i < numberOfRequests; i++)
            {
                double interArrivalTime = Distribution.ExponentialDistribution(rand.NextSingle(), lambda);
                currentTime += interArrivalTime;
                Arrivals[i] = currentTime;
            }
            double serviceTime = GenerateErlang3ServiceTime();
            Processing[0] = Arrivals[0] + serviceTime;
            for (int i = 1; i < numberOfRequests - 1; i++)
            {
                serviceTime = GenerateErlang3ServiceTime();
                if (serviceTime + Arrivals[i - 1] < Arrivals[i])
                {
                    Processing[i] = Arrivals[i] + serviceTime;
                }
                else
                {
                    Processing[i] = Processing[i - 1] + serviceTime;
                }
            }



            averageRequestsInSystem = totalSystemTime / currentTime;
            averageRequestsInQueue = totalWaitingTime / currentTime;
            averageTimeInSystem = totalSystemTime / numberOfRequests;
            averageTimeInQueue = totalWaitingTime / numberOfRequests;
        }

        public void Run2(int numberOfRequests)
        {
            Random rand = new Random();
            double currentTime = 0;
            double totalWaitingTime = 0;
            double totalSystemTime = 0;
            int requestsInQueue = 0;

            for (int i = 0; i < numberOfRequests; i++)
            {
                double interArrivalTime = -Math.Log(rand.NextDouble()) / lambda;
                currentTime += interArrivalTime;

                double serviceTime = GenerateErlang3ServiceTime();
                double serviceCompletionTime = currentTime + serviceTime;

                if (currentTime < serviceCompletionTime)
                {
                    arrivalTimes.Enqueue(currentTime);
                }
                else
                {
                    requestsInQueue++;
                    totalWaitingTime += currentTime - arrivalTimes.Dequeue();
                }

                totalSystemTime += serviceTime + totalWaitingTime;
            }

            averageRequestsInSystem = totalSystemTime / currentTime;
            averageRequestsInQueue = totalWaitingTime / currentTime;
            averageTimeInSystem = totalSystemTime / numberOfRequests;
            averageTimeInQueue = totalWaitingTime / numberOfRequests;
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
