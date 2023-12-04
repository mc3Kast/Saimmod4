
using Math4Saimmod.Lib.LemRandom;

namespace Math4Saimmod.Lib.Elements
{
    public class Processor : IElement, IGet
    {
        private readonly Random _random;
        private readonly IGet _element;
        private readonly float _intensity;
        public float _time = 0;
        public uint _tickCount = 1;
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
            else
            {
                return false;
            }
        }

        public void Tick()
        {
            if (_busy)
            {
                float t = Distribution.ExponentialDistribution(_random.NextSingle(), _intensity);
                _time += t;
                if (_tickCount % 3 == 0)
                {
                    _element.Get();
                    _busy = false;
                }                
                _tickCount++;
            }
        }

        //lab 4
        public void Tick(float f)
        {
            if (_busy)
            {
                float t = Distribution.ExponentialDistribution(f, _intensity);
                _time += t;
                if (_tickCount % 3 == 0)
                {
                    _element.Get();
                    _busy = false;
                }
                _tickCount++;
            }
        }

        public bool Busy { get { return _busy; } set { _busy = value; } }
        public IGet NextElement { get { return _element; } }
    }
}
