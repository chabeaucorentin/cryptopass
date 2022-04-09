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
            RemoveCommand = new DelegateCommand(Remove, CanExecuteRemove);
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

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }
        #endregion

        #region METHODS
        public void Add(object parameter)
        {
            PaymentViewModel NewPayment = new(new Payment());
            ListPayments.Add(NewPayment);
            SelectedPayment = NewPayment;
            RemoveCommand.RaiseCanExecuteChanged();
        }

        public void Remove(object parameter)
        {
            ListPayments.Remove(SelectedPayment);
            SelectedPayment = ListPayments.FirstOrDefault();
            RemoveCommand.RaiseCanExecuteChanged();
        }

        public bool CanExecuteRemove(object parameter)
        {
            return ListPayments.Count > 0;
        }
        #endregion
    }
}
