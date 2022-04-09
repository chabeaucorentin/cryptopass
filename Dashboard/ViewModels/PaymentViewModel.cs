using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonViewModels;
using SecureLibrary;

namespace Dashboard.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private readonly Payment _payment;
        #endregion

        #region CONSTRUCTORS
        public PaymentViewModel(Payment payment)
        {
            _payment = payment;
        }
        #endregion

        #region GETTERS/SETTERS
        public string Name
        {
            get { return _payment.Name; }
            set
            {
                _payment.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Number
        {
            get { return _payment.Number; }
            set
            {
                _payment.Number = value;
                OnPropertyChanged(nameof(Number));
            }
        }

        public string Cvv
        {
            get { return _payment.Cvv; }
            set
            {
                _payment.Cvv = value;
                OnPropertyChanged(nameof(Cvv));
            }
        }

        public int Year
        {
            get { return _payment.Year; }
            set
            {
                _payment.Year = value;
                OnPropertyChanged(nameof(Year));
            }
        }

        public int Month
        {
            get { return _payment.Month; }
            set
            {
                _payment.Month = value;
                OnPropertyChanged(nameof(Month));
            }
        }
        #endregion
    }
}
