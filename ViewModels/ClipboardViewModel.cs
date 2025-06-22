using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiPlanTurismo.ViewModels
{
    public class ClipboardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Copy { private set; get; }
        public ICommand Paste { private set; get; }
        public ICommand Verify { private set; get; }
        public ICommand Clean { private set; get; }

        public string CopyDataValue { get; set; }
        public string PasteDataValue { get; set; }
        public string LastDataCopied { get; set; }
        public string CurrentValue { get; set; }

        public ClipboardViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            Copy = new Command(execute: () => OnCopy());
            Paste = new Command(execute: () => OnPaste());
            Verify = new Command(execute: () => OnCheck());
            Clean = new Command(execute: () => OnClear());
        }

        public void StartObservation()
        {
            Clipboard.ClipboardContentChanged += OnClipboardContentChanged;
        }

        public void StopObservation()
        {
            Clipboard.ClipboardContentChanged -= OnClipboardContentChanged;
        }

        private void OnClipboardContentChanged(object sender, EventArgs args)
        {
            LastDataCopied = $" {DateTime.UtcNow:T}";
            OnPropertyChanged(nameof(LastDataCopied));
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnCopy()
        {
            OnPropertyChanged(nameof(CopyDataValue));
            await Clipboard.SetTextAsync(CopyDataValue);
        }

        private async void OnPaste()
        {
            var text = await Clipboard.GetTextAsync();
            if (!string.IsNullOrWhiteSpace(text))
            {
                PasteDataValue = text;
            }
            OnPropertyChanged(nameof(PasteDataValue));
        }

        private void OnCheck()
        {
            CurrentValue = Clipboard.HasText ? "TEXTO EN PORTAPAPELES" : "SIN TEXTO";
            OnPropertyChanged(nameof(CurrentValue));
        }

        private async void OnClear()
        {
            await Clipboard.SetTextAsync(null);
            CopyDataValue = "";
            PasteDataValue = "";
            OnPropertyChanged(nameof(CopyDataValue));
            OnPropertyChanged(nameof(PasteDataValue));
            OnCheck();
        }
    }
}
