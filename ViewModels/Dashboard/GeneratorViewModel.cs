using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Dashboard
{
    public class GeneratorViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private int _length;
        private bool _useNumbers;
        private bool _useLowLetters;
        private bool _useCapLetters;
        private bool _useSpecialChar;
        private string? _password;
        #endregion

        #region CONSTRUCTORS
        public GeneratorViewModel()
        {
            _length = 16;
            _useNumbers = true;
            _useLowLetters = true;
            _useCapLetters = true;
            _useSpecialChar = false;
            Generate();
            GenerateCommand = new DelegateCommand(Generate);
        }
        #endregion

        #region GETTERS/SETTERS
        public string LengthText
        {
            get { return "Longueur (" + _length + ")"; }
        }

        public int Length
        {
            get { return _length; }
            set
            {
                if (_length != value)
                {
                    _length = value;
                    Generate();
                    OnPropertyChanged(nameof(Length));
                    OnPropertyChanged(nameof(LengthText));
                }
            }
        }

        public bool UseNumbers
        {
            get { return _useNumbers; }
            set
            {
                _useNumbers = value;
                Generate();
                OnPropertyChanged(nameof(UseNumbers));
            }
        }

        public bool UseLowLetters
        {
            get { return _useLowLetters; }
            set
            {
                _useLowLetters = value;
                Generate();
                OnPropertyChanged(nameof(UseLowLetters));
            }
        }

        public bool UseCapLetters
        {
            get { return _useCapLetters; }
            set
            {
                _useCapLetters = value;
                Generate();
                OnPropertyChanged(nameof(UseCapLetters));
            }
        }

        public bool UseSpecialChar
        {
            get { return _useSpecialChar; }
            set
            {
                _useSpecialChar = value;
                Generate();
                OnPropertyChanged(nameof(UseSpecialChar));
            }
        }

        public string? Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public DelegateCommand GenerateCommand { get; set; }
        #endregion

        #region METHODS
        public void Generate(object? parameter = null)
        {
            string pass = "";
            string characters = "";
            Random rand = new Random();

            if (_useNumbers)
            {
                characters += "0123456789";
            }
            if (_useLowLetters)
            {
                characters += "abcdefghijklmnopkrstuvwxyz";
            }
            if (_useCapLetters)
            {
                characters += "ABCDEFGHIJKLMNOPKRSTUVWXYZ";
            }
            if (_useSpecialChar)
            {
                characters += "@&$!#?";
            }

            if (characters.Length > 0)
            {
                for (int i = 0; i < _length; i++)
                {
                    pass += characters[rand.Next(characters.Length)];
                }
            }

            Password = pass;
        }
        #endregion
    }
}
