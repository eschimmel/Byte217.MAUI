using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Byte217.MAUI.ViewModels.Processors
{
    public partial class KeyProcessor : ObservableObject, IKeyProcessor
    {
        public event EventHandler KeyPressed = null;

        private string ProcessText = string.Empty;

        [ObservableProperty]
        public string _text = string.Empty;

        public KeyProcessor()
        {
        }

        public void KeyIsPressed()
        {
            KeyPressed?.Invoke(this, EventArgs.Empty);
        }

        [RelayCommand]
        public void BackspacePress()
        {
            KeyIsPressed();

            ProcessText = ProcessText.TrimLastCharacter();
            Text = Text.TrimLastCharacter();            
        }

        [RelayCommand]
        public void SpacePress()
        {
            KeyIsPressed();

            ProcessText += " ";
            Text += " ";

            // Only allow one space
            ProcessText = ProcessText.Replace("  ", " ");
            Text = Text.Replace("  ", " ");
        }

        [RelayCommand]
        public void ClearPress()
        {
            KeyIsPressed();

            ProcessText = string.Empty;
            Text = string.Empty;
        }

        [RelayCommand]
        public void KeyPress(string key)
        {
            KeyIsPressed();

            bool isPunctuation = key.IsPunctuation();

            bool isEndOfSentence = Text.IsEndOfSentence();
            bool isLastCharacterComma = Text.IsLastCharacterComma();
            bool isFirstCharacter = string.IsNullOrWhiteSpace(Text);

            if (isPunctuation || isEndOfSentence || isLastCharacterComma)
            {
                ProcessText = ProcessText.TrimEnd();
                Text = Text.TrimEnd();
            }

            if (isEndOfSentence && !isPunctuation)
            {
                key = " " + key.ToUpper();
            }

            if (isFirstCharacter && !isPunctuation)
            {
                key = key.ToUpper();
            }

            if (isLastCharacterComma && !isPunctuation)
            {
                key = " " + key;
            }

            ProcessText += key;
            Text += key;
        }
    }
}
