using Byte217.MAUI.Models;

namespace Byte217.MAUI.ViewModels.Processors
{
    public interface IKeyProcessor
    {
        event EventHandler KeyPressed;
                
        void KeyIsPressed();

        void BackspacePress();
        void ClearPress();
        void SpacePress();
    }
}