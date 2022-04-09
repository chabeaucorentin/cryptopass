using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;
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
            AddCommand = new DelegateCommand(Add);
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
        public void Add(object parameter)
        {
            PaymentViewModel NewPayment = new(new Payment());
            ListPayments.Add(NewPayment);
            SelectedPayment = NewPayment;
        }

        public DelegateCommand AddCommand { get; set; }
        #endregion
    }
}
