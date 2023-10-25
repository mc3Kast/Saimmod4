
namespace Math4Saimmod.Lib.Elements
{
    public class Exit : IGet
    {
        public uint finishedRequests;

        public Exit()
        {
            finishedRequests = 0;
        }
        public bool Get()
        {
            finishedRequests++;
            return true;
        }
    }
}
