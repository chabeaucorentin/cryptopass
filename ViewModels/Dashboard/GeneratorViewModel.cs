using Models;

namespace ViewModels.Dashboard
{
    public class GeneratorViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private readonly Generate _generate;
        #endregion

        #region CONSTRUCTORS
        public GeneratorViewModel()
        {
            _generate = new Generate();
            GenerateCommand = new DelegateCommand(Generate);
        }
        #endregion

        #region GETTERS/SETTERS
        public string LengthText
        {
            get { return "Longueur (" + _generate.Length + ")"; }
        }

        public int Length
        {
            get { return _generate.Length; }
            set
            {
                if (_generate.Length != value)
                {
                    _generate.Length = value;
                    Generate();
                    OnPropertyChanged(nameof(Length));
                    OnPropertyChanged(nameof(LengthText));
                }
            }
        }

        public bool UseNumbers
        {
            get { return _generate.UseNumbers; }
            set
            {
                _generate.UseNumbers = value;
                Generate();
                OnPropertyChanged(nameof(UseNumbers));
            }
        }

        public bool UseLowLetters
        {
            get { return _generate.UseLowLetters; }
            set
            {
                _generate.UseLowLetters = value;
                Generate();
                OnPropertyChanged(nameof(UseLowLetters));
            }
        }

        public bool UseCapLetters
        {
            get { return _generate.UseCapLetters; }
            set
            {
                _generate.UseCapLetters = value;
                Generate();
                OnPropertyChanged(nameof(UseCapLetters));
            }
        }

        public bool UseSpecialChar
        {
            get { return _generate.UseSpecialChar; }
            set
            {
                _generate.UseSpecialChar = value;
                Generate();
                OnPropertyChanged(nameof(UseSpecialChar));
            }
        }

        public string Password
        {
            get { return _generate.GeneratePass(); }
        }

        public DelegateCommand GenerateCommand { get; set; }
        #endregion

        #region METHODS
        public void Generate(object? parameter = null)
        {
            OnPropertyChanged(nameof(Password));
        }
        #endregion
    }
}
