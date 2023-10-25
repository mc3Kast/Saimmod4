
using Math4Saimmod.Lib.LemRandom;

namespace Math4Saimmod.Lib.Elements
{
    public class Processor : IElement, IGet
    {
        private readonly Random _random;
        private readonly IGet _element;
        private readonly float _intensity;
        private float _progress = 0;
        private bool _busy = false;

        public Processor(Random random, IGet element, float intensity)
        {
            _random = random;
            _intensity = intensity;
            _element = element;
        }

        public bool Get()
        {
            if (!_busy)
            {
                _busy = true;
                return true;
            }
            else return false;
        }

        public void Tick()
        {
            if (_busy)
            {
                _progress = Distribution.ExponentialDistribution(_random.NextSingle(), _intensity);
                while (_progress >= 1)
                {
                    _busy = false;
                    _element.Get();
                    _progress--;
                }
            }
        }
    }
}
