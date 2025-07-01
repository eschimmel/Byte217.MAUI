using Byte217.MAUI.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Byte217.MAUI.ObservableModels
{
    public class ObservableKeyboard : Keyboard, INotifyPropertyChanged
    {
        public new char[] Row1
        {
            get
            {
                return base.Row1;
            }
            set
            {
                base.Row1 = value;
                OnPropertChanged();
            }
        }

        public new char[] Row2
        {
            get
            {
                return base.Row2;
            }
            set
            {
                base.Row2 = value;
                OnPropertChanged();
            }
        }

        public new char[] Row3
        {
            get
            {
                return base.Row3;
            }
            set
            {
                base.Row3 = value;
                OnPropertChanged();
            }
        }

        public new void ToUpper()
        {
            base.ToUpper();

            OnPropertChanged(nameof(Row1));
            OnPropertChanged(nameof(Row2));
            OnPropertChanged(nameof(Row3));            
        }

        public new void ToLower()
        {
            base.ToLower();

            OnPropertChanged(nameof(Row1));
            OnPropertChanged(nameof(Row2));
            OnPropertChanged(nameof(Row3));
        }

        protected void OnPropertChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
