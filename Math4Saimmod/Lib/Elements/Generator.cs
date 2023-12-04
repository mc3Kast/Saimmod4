
using Math4Saimmod.Lib.LemRandom;

namespace Math4Saimmod.Lib.Elements
{
    public class Generator : IElement
    {
        private readonly IGet _element;
        private readonly Random _random;
        private readonly float _intensity;
        public float _time = 0;
        public uint generatedRequests = 0;

        public Generator(IGet element, Random random, float intensity)
        {
            _element = element;
            _random = random;
            _intensity = intensity;
        }

        public void Tick()
        {
            _time += Distribution.ExponentialDistribution(_random.NextSingle(), _intensity);
            _element.Get();
            generatedRequests++;
        }

        //lab 4
        public void Tick(float f)
        {
            _time += Distribution.ExponentialDistribution(f, _intensity);
            _element.Get();
            generatedRequests++;
        }
    }
}
