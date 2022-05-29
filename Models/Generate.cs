namespace Models
{
    public class Generate
    {
        #region MEMBER VARIABLES
        private int _length;
        private bool _useNumbers;
        private bool _useLowLetters;
        private bool _useCapLetters;
        private bool _useSpecialChar;
        #endregion

        #region CONSTRUCTORS
        public Generate()
        {
            _length = 16;
            _useNumbers = true;
            _useLowLetters = true;
            _useCapLetters = true;
            _useSpecialChar = false;
        }
        #endregion

        #region GETTERS/SETTERS
        public int Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public bool UseNumbers
        {
            get { return _useNumbers; }
            set { _useNumbers = value; }
        }

        public bool UseLowLetters
        {
            get { return _useLowLetters; }
            set { _useLowLetters = value; }
        }

        public bool UseCapLetters
        {
            get { return _useCapLetters; }
            set { _useCapLetters = value; }
        }

        public bool UseSpecialChar
        {
            get { return _useSpecialChar; }
            set { _useSpecialChar = value; }
        }
        #endregion

        #region METHODS
        public string GeneratePass()
        {
            string pass = "";
            string characters = "";
            Random rand = new();

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

            return pass;
        }
        #endregion
    }
}
