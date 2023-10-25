
namespace Math4Saimmod.Lib.Elements
{
    public class Queue : IElement, IGet
    {
        private readonly IGet _element;
        private uint _requests = 0;
        public uint ticksInQueue = 0;

        public Queue(IGet element)
        {
            _element = element;
        }

        public bool Get()
        {
            _requests++;
            if (_element.Get())
            {
                _requests--;
            }
            else ticksInQueue++;
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
                else ticksInQueue++;
            }
        }
    }
}
