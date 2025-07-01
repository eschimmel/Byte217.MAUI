using Byte217.MAUI.Models;
using Byte217.MAUI.Models.Constants;
using Byte217.MAUI.Models.Factories;
using Byte217.MAUI.ObservableModels;
using Byte217.MAUI.ViewModels.Factories;
using Byte217.MAUI.ViewModels.Processors;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Byte217.MAUI.ViewModels
{
    [ObservableObject]
    public partial class MainViewModel : ViewModelBase
    {
        private readonly IKeyboardFactory _keyboardFactory;
        private readonly IPageLayoutFactory _pageLayoutFactory;
        private readonly IKeyProcessorFactory _keyProcessorFactory;

        public byte Platform { get; set; }
        public byte Idiom { get; set; }

        [ObservableProperty]
        public ObservablePageLayout _pageLayout = new();

        private Member _member = new();

        [ObservableProperty]
        public ObservableKeyboard _keyboard = new();

        [ObservableProperty]
        public bool _isCapsLocked = false;
        [ObservableProperty]
        public bool _showKeyboardSettings = true;
        [ObservableProperty]
        public bool _showDictionary = false;
        [ObservableProperty]
        public bool _showHistory = false;

        [ObservableProperty]
        public KeyProcessor _keyProcessor;

        private List<PageLayout> _pageLayouts = new();

        public MainViewModel()
            : base()
        {
        }

        public MainViewModel(IKeyboardFactory keyboardFactory,
                             IPageLayoutFactory pageLayoutFactory,
                             IKeyProcessorFactory keyProcessorFactory)
            : base()
        {
            _keyboardFactory = keyboardFactory;
            _pageLayoutFactory = pageLayoutFactory;

            _keyProcessorFactory = keyProcessorFactory;
        }

        public void Initialize(byte platform, byte idiom)
        {
            Platform = platform;
            Idiom = idiom;

            _member = GetMember();

            KeyProcessor = CreateKeyProcessor();
            Keyboard = CreateKeyboard();
        }

        private static Member GetMember()
        {
            // Retrieve member from database
            Member member = new();
            member.PageLayoutType = PageLayoutType.Minimal;

            return member;
        }

        public void CreatePageLayouts(double width, double height, Thickness safeArea)
        {
            _pageLayouts = _pageLayoutFactory.CreatePageLayouts(width, height, Idiom, safeArea);

            // Setting the PageLayout will raise a OnPropertyChanged, which will redraw the screen using the new page layout
            PageLayout = SelectPageLayout();
        }

        private ObservablePageLayout SelectPageLayout()
        {
            // Return the layout the user selected
            PageLayout pageLayout = _pageLayouts.FirstOrDefault(i => i.PageLayoutType == _member.PageLayoutType);
            if (pageLayout == null)
            {
                // Return the prefered layout, this is the one with the largest Multiplier value
                pageLayout = _pageLayouts.FirstOrDefault(i => i.IsPreferred) ?? new PageLayout();
            }

            return pageLayout.ToObservablePageLayout();
        }

        private ObservableKeyboard CreateKeyboard()
        {
            Keyboard keyboard = _keyboardFactory.CreateKeyboard();
            return keyboard.ToObservableKeyboard();
        }

        private KeyProcessor CreateKeyProcessor()
        {
            return _keyProcessorFactory.Create() as KeyProcessor;
        }

        [RelayCommand]
        public void CapsLockPress()
        {
            IsCapsLocked = !IsCapsLocked;

            KeyProcessor.KeyIsPressed();
        }

        public void KeyPress(string key)
        {
            KeyProcessor.KeyPress(key);
        }

        [RelayCommand]
        public void KeyboardSettingsPress()
        {
            ShowKeyboardSettings = true;
            ShowDictionary = false;
            ShowHistory = false;
        }

        [RelayCommand]
        public void DictionaryPress()
        {
            ShowKeyboardSettings = false;
            ShowDictionary = true;
            ShowHistory = false;
        }

        [RelayCommand]
        public void HistoryPress()
        {
            ShowKeyboardSettings = false;
            ShowDictionary = false;
            ShowHistory = true;
        }

        public void SaveSettingsPress()
        {
            // Save settings
        }

        public void CancelSettingsPress()
        {
            // Cancel changes
        }
    }
}
