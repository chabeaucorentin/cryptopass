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
            ListNotes.Remove(SelectedNote);
            SelectedNote = ListNotes.FirstOrDefault();
        }
        #endregion
    }
}
