using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Runtime.Versioning;
using System.Text.Json;
using Models;

namespace ViewModels.Dashboard
{
    public class PasswordsViewModel : BaseViewModel, IManageSecureObject
    {
        #region MEMBER VARIABLES
        private PasswordViewModel? _selectedPassword;
        #endregion

        #region CONSTRUCTORS
        public PasswordsViewModel()
        {
            ListPasswords = new ObservableCollection<PasswordViewModel>();
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
        }
        #endregion

        #region GETTERS/SETTERS
        public PasswordViewModel? SelectedPassword
        {
            get { return _selectedPassword; }
            set
            {
                _selectedPassword = value;
                OnPropertyChanged(nameof(SelectedPassword));
                OnPropertyChanged(nameof(IsSelectedPassword));
            }
        }

        public bool IsSelectedPassword
        {
            get { return SelectedPassword != null; }
        }

        public ObservableCollection<PasswordViewModel> ListPasswords { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }
        #endregion

        #region METHODS
        public void Add(object parameter)
        {
            PasswordViewModel NewPass = new(new Password());
            ListPasswords.Add(NewPass);
            SelectedPassword = NewPass;
        }

        public void Remove(object parameter)
        {
            if (SelectedPassword != null)
            {
                ListPasswords.Remove(SelectedPassword);
                SelectedPassword = ListPasswords.FirstOrDefault();
            }
        }

        [SupportedOSPlatform("windows")]
        public void Load(string? file = null)
        {
            string fileName = file ?? (AppSettings.GetPath() + @"\Passwords.json");
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                List<Password>? passwords = JsonSerializer.Deserialize<List<Password>>(jsonString);
                if (passwords != null)
                {
                    foreach (Password pass in passwords)
                    {
                        ListPasswords.Add(new PasswordViewModel(pass));
                    }
                    if (ListPasswords.Count > 0)
                    {
                        SelectedPassword = ListPasswords.FirstOrDefault();
                    }
                }
            }
        }

        [SupportedOSPlatform("windows")]
        public void Save(string? file = null)
        {
            string fileName = file ?? (AppSettings.GetPath() + @"\Passwords.json");
            if (file != null || ListPasswords.Count > 0)
            {
                string jsonString = JsonSerializer.Serialize(ListPasswords);
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
            string fileName = AppSettings.GetPath() + @"\Passwords.json";
            if (File.Exists(fileName))
            {
                string jsonFile = File.ReadAllText(fileName);
                JArray json1 = JArray.Parse(jsonFile);
                JArray json2 = JArray.Parse(JsonSerializer.Serialize(ListPasswords));
                return !JToken.DeepEquals(json1, json2);
            }
            else if (ListPasswords.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
