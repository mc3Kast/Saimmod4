
namespace Math4Saimmod.Lib.Elements
{
    public class Model
    {
        private Random _random = new Random();
        public Exit exit;
        public Processor processor1;
        public Queue queue;
        public Generator generator;

        public Model(float p1, float p2)
        {
            exit = new Exit();
            processor1 = new Processor(_random, exit, p2);
            queue = new Queue(processor1);
            generator = new Generator(queue, _random,  p1);
        }

        public void Run(int n)
        {
            for (int i = 0; i < n; i++)
            {
                float f = _random.NextSingle();
                processor1.Tick();
                queue.Tick();
                generator.Tick();
            }
        }
    }
}
