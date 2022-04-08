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
    public class NotesViewModel : BaseViewModel, IAddSecureObject
    {
        #region MEMBER VARIABLES
        private NoteViewModel? _selectedNote;
        #endregion

        #region CONSTRUCTORS
        public NotesViewModel()
        {
            ListNotes = new ObservableCollection<NoteViewModel>();
            AddCommand = new AddCommand(this);
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
            }
        }

        public ObservableCollection<NoteViewModel> ListNotes { get; set; }
        #endregion

        #region METHODS
        public void Add()
        {
            NoteViewModel NewNote = new(new Note());
            ListNotes.Add(NewNote);
            SelectedNote = NewNote;
        }

        public ICommand AddCommand { get; set; }
        #endregion
    }
}
