
using Math4Saimmod.Lib.LemRandom;

namespace Math4Saimmod.Lib.Elements
{
    public class Generator : IElement
    {
        private readonly IGet _element;
        private readonly Random _random;
        private readonly float _intensity;
        private float _progress = 0;
        public uint generatedRequests = 0;

        public Generator(IGet element, Random random, float intensity)
        {
            _element = element;
            _random = random;
            _intensity = intensity;
        }

        public void Tick()
        {
            _progress += Distribution.ExponentialDistribution(_random.NextSingle(), _intensity);
            while (_progress >= 1)
            {
                _element.Get();
                generatedRequests++;
                _progress--;
            }
        }
    }
}
