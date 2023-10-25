
namespace Math4Saimmod.Lib.Elements
{
    public class Generator : IElement
    {
        private readonly IGet _element;
        private uint _tickCounts;
        public uint generatedRequests = 0;

        public Generator(IGet element)
        {
            _element = element;
            _tickCounts = 0;
        }

        public void Tick()
        {
            _tickCounts++;
            if(_tickCounts % 2 == 0)
            {
                _element.Get();
                generatedRequests++;
            }
        }
    }
}
