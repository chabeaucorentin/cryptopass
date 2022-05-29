using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Runtime.Versioning;
using System.Text.Json;
using Models;

namespace ViewModels.Dashboard
{
    public class PaymentsViewModel : BaseViewModel, IManageSecureObject
    {
        #region MEMBER VARIABLES
        private PaymentViewModel? _selectedPayment;
        #endregion

        #region CONSTRUCTORS
        public PaymentsViewModel()
        {
            ListPayments = new ObservableCollection<PaymentViewModel>();
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
        }
        #endregion

        #region GETTERS/SETTERS
        public PaymentViewModel? SelectedPayment
        {
            get { return _selectedPayment; }
            set
            {
                _selectedPayment = value;
                OnPropertyChanged(nameof(SelectedPayment));
                OnPropertyChanged(nameof(IsSelectedPayment));
            }
        }

        public bool IsSelectedPayment
        {
            get { return SelectedPayment != null; }
        }

        public ObservableCollection<PaymentViewModel> ListPayments { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }
        #endregion

        #region METHODS
        public void Add(object parameter)
        {
            PaymentViewModel NewPayment = new(new Payment());
            ListPayments.Add(NewPayment);
            SelectedPayment = NewPayment;
        }

        public void Remove(object parameter)
        {
            if (SelectedPayment != null)
            {
                ListPayments.Remove(SelectedPayment);
                SelectedPayment = ListPayments.FirstOrDefault();
            }
        }

        [SupportedOSPlatform("windows")]
        public void Load(string? file = null)
        {
            string fileName = file ?? (AppSettings.GetPath() + @"\Payments.json");
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                List<Payment>? payments = JsonSerializer.Deserialize<List<Payment>>(jsonString);
                if (payments != null)
                {
                    foreach (Payment payment in payments)
                    {
                        ListPayments.Add(new PaymentViewModel(payment));
                    }
                    if (ListPayments.Count > 0)
                    {
                        SelectedPayment = ListPayments.FirstOrDefault();
                    }
                }
            }
        }

        [SupportedOSPlatform("windows")]
        public void Save(string? file = null)
        {
            string fileName = file ?? (AppSettings.GetPath() + @"\Payments.json");
            if (file != null || ListPayments.Count > 0)
            {
                string jsonString = JsonSerializer.Serialize(ListPayments);
                File.WriteAllText(fileName, jsonString);
            }
            else if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        [SupportedOSPlatform("windows")]
        public bool HasChanged()
        {
            string fileName = AppSettings.GetPath() + @"\Payments.json";
            if (File.Exists(fileName))
            {
                string jsonFile = File.ReadAllText(fileName);
                JArray json1 = JArray.Parse(jsonFile);
                JArray json2 = JArray.Parse(JsonSerializer.Serialize(ListPayments));
                return !JToken.DeepEquals(json1, json2);
            }
            else if (ListPayments.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
