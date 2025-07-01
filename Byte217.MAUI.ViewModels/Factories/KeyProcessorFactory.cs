using Byte217.MAUI.ViewModels.Processors;

namespace Byte217.MAUI.ViewModels.Factories
{
    public class KeyProcessorFactory : IKeyProcessorFactory
    {
        public KeyProcessorFactory()
        {
        }

        public IKeyProcessor Create()
        {
            return new KeyProcessor();
        }
    }
}
