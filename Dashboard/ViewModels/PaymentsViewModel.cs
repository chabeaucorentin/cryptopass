using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Dashboard.Commands;
using SecureLibrary;

namespace Dashboard.ViewModels
{
    public class PaymentsViewModel : BaseViewModel, IAddSecureObject
    {
        #region MEMBER VARIABLES
        private PaymentViewModel? _selectedPayment;
        #endregion

        #region CONSTRUCTORS
        public PaymentsViewModel()
        {
            ListPayments = new ObservableCollection<PaymentViewModel>();
            AddCommand = new AddCommand(this);
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
            }
        }

        public ObservableCollection<PaymentViewModel> ListPayments { get; set; }
        #endregion

        #region METHODS
        public void Add()
        {
            PaymentViewModel NewPayment = new(new Payment());
            ListPayments.Add(NewPayment);
            SelectedPayment = NewPayment;
        }

        public ICommand AddCommand { get; set; }
        #endregion
    }
}
