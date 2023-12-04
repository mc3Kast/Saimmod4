
using Math4Saimmod.Lib.LemRandom;

namespace Math4Saimmod.Lib.Elements
{
    public class Queue : IElement, IGet
    {
        private readonly IGet _element;
        private uint _requests = 0;
        //private readonly Random _random;
        public uint ticksInQueue = 0;
        public float timeInQueue = 0;

        public Queue(IGet element)
        {
            _element = element;
            //_random = random;
        }

        public bool Get()
        {
            _requests++;
            if (_element.Get())
            {
                _requests--;
            }
            return true;
        }

        public void Tick()
        {
            if (_requests > 0)
            {
                if (_element.Get())
                {
                    _requests--;
                }
                else ticksInQueue += _requests;
            }
        }
        public uint Requests { get { return _requests; } set { _requests = value; } }
        public IGet NextElement { get { return _element; } }
    }
}
