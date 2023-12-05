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

        /*Логика такова, у нас есть временная линия, на ней расположены события - генерация заявки, обработка заявки.
        Нам нужно правильно расположить эти события на линии, ведь хоть обработчик работает в среднем быстрее генератора,
        не факт что у нас не сгенерируется ещё несколько заявок пока будет обрабатываться прошлая.
        Как я сделал - поток генератора простейший, мы фиксируем на временной линии генерации заявок в массив Arrivals.
        После мы фиксируем время на обработку каждой заявки в массив ProcessingTimes.
        И находим время на временной линии когда каждая заявка была обработана, беря во внимание что процессор мог быть
        как пуст и начать обрабатывать сразу же заявку
        так и быть занятым и начать обрабатывать после обработки предыдущей заявки.

        Время в очереди находим просто сравнивая время генерации заявки с добавлением времени её обработки
        и временем окончания её обработки,
        если есть розница добавляем её как время в очереди.

        Вообщем немного не сходятся статистические данные с моделируимыми(время в очереди сильно не сходится),
        так что я верю ты найдешь что работает не так и исправишь*/

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
