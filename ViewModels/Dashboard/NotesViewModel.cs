using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Models;

namespace ViewModels.Dashboard
{
    public class NotesViewModel : BaseViewModel, IManageSecureObject
    {
        #region MEMBER VARIABLES
        private NoteViewModel? _selectedNote;
        #endregion

        #region CONSTRUCTORS
        public NotesViewModel()
        {
            ListNotes = new ObservableCollection<NoteViewModel>();
            AddCommand = new DelegateCommand(Add);
            RemoveCommand = new DelegateCommand(Remove);
        }
        #endregion

        #region GETTERS/SETTERS
        public NoteViewModel? SelectedNote
        {
            get { return _selectedNote; }
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
                OnPropertyChanged(nameof(IsSelectedNote));
            }
        }

        public bool IsSelectedNote
        {
            get { return SelectedNote != null; }
        }

        public ObservableCollection<NoteViewModel> ListNotes { get; set; }

        public DelegateCommand AddCommand { get; set; }

        public DelegateCommand RemoveCommand { get; set; }
        #endregion

        #region METHODS
        public void Add(object parameter)
        {
            NoteViewModel NewNote = new(new Note());
            ListNotes.Add(NewNote);
            SelectedNote = NewNote;
        }

        public void Remove(object parameter)
        {
            if (SelectedNote != null)
            {
                ListNotes.Remove(SelectedNote);
                SelectedNote = ListNotes.FirstOrDefault();
            }
        }

        public void Load(string? file = null)
        {
            string fileName = file ?? (AppSettings.GetPath() + @"\Notes.json");
            if (File.Exists(fileName))
            {
                string jsonString = File.ReadAllText(fileName);
                List<Note>? notes = JsonSerializer.Deserialize<List<Note>>(jsonString);
                if (notes != null)
                {
                    foreach (Note note in notes)
                    {
                        ListNotes.Add(new NoteViewModel(note));
                    }
                    if (ListNotes.Count > 0)
                    {
                        SelectedNote = ListNotes.FirstOrDefault();
                    }
                }
            }
        }

        public void Save(string? file = null)
        {
            string fileName = file ?? (AppSettings.GetPath() + @"\Notes.json");
            if (ListNotes.Count > 0)
            {
                string jsonString = JsonSerializer.Serialize(ListNotes);
                File.WriteAllText(fileName, jsonString);
            }
            else if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }

        public bool HasChanged()
        {
            string fileName = AppSettings.GetPath() + @"\Notes.json";
            if (File.Exists(fileName))
            {
                string jsonFile = File.ReadAllText(fileName);
                JArray json1 = JArray.Parse(jsonFile);
                JArray json2 = JArray.Parse(JsonSerializer.Serialize(ListNotes));
                return !JToken.DeepEquals(json1, json2);
            }
            else if (ListNotes.Count > 0)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
