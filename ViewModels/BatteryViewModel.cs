using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace MauiPlanTurismo.ViewModels
{
    public class BatteryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public double BatteryLevel { get; set; }
        public BatteryState BatteryState { get; set; }
        public BatteryPowerSource ChargeSource { get; set; }
        public EnergySaverStatus EnergySaverStatus { get; set; }
        public string ObservationInfo { get; set; }
        public string BatteryImage { get; set; }
        public bool ShowImage { get; set; }

        public ICommand StartBatteryMonitor { get; private set; }
        public ICommand StopBatteryMonitor { get; private set; }

        public BatteryViewModel()
        {
            InitializeCommands();
            AssignValues();
            ShowImage = false;
            OnPropertyChanged(nameof(ShowImage));
        }

        private void InitializeCommands()
        {
            StartBatteryMonitor = new Command(() => StartObservation());
            StopBatteryMonitor = new Command(() => StopObservation());
        }

        private void AssignValues()
        {
            BatteryLevel = Battery.ChargeLevel * 100;
            BatteryState = Battery.State;
            ChargeSource = Battery.PowerSource;
            EnergySaverStatus = Battery.EnergySaverStatus;

            if (BatteryLevel <= 20)
                BatteryImage = "bateria_20.png";
            else if (BatteryLevel > 20 && BatteryLevel < 80)
                BatteryImage = "bateria_40.png";
            else if (BatteryLevel >= 80 && BatteryLevel < 100)
                BatteryImage = "bateria_80.png";
            else if (BatteryLevel == 100)
                BatteryImage = "bateria_100.png";

            OnPropertyChanged(nameof(BatteryLevel));
            OnPropertyChanged(nameof(BatteryState));
            OnPropertyChanged(nameof(ChargeSource));
            OnPropertyChanged(nameof(EnergySaverStatus));
            OnPropertyChanged(nameof(BatteryImage));
        }

        public void StartObservation()
        {
            Battery.BatteryInfoChanged += OnBatteryInfoChanged;
            Battery.EnergySaverStatusChanged += OnEnergySaverStatusChanged;
            SetObservationProperties("Observando Bateria", true);
        }

        public void StopObservation()
        {
            Battery.BatteryInfoChanged -= OnBatteryInfoChanged;
            Battery.EnergySaverStatusChanged -= OnEnergySaverStatusChanged;
            SetObservationProperties("Stopped monitoring battery", false);
        }

        private void SetObservationProperties(string info, bool show)
        {
            ObservationInfo = info;
            ShowImage = show;
            OnPropertyChanged(nameof(ObservationInfo));
            OnPropertyChanged(nameof(ShowImage));
        }

        private void OnBatteryInfoChanged(object sender, BatteryInfoChangedEventArgs e)
        {
            AssignValues();
        }

        private void OnEnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
        {
            AssignValues();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}