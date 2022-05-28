using Models;

namespace ViewModels.Dashboard
{
    public class NoteViewModel : BaseViewModel
    {
        #region MEMBER VARIABLES
        private readonly Note _note;
        #endregion

        #region CONSTRUCTORS
        public NoteViewModel(Note note)
        {
            _note = note;
        }
        #endregion

        #region GETTERS/SETTERS
        public string Name
        {
            get { return _note.Name; }
            set
            {
                _note.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Content
        {
            get { return _note.Content; }
            set
            {
                _note.Content = value;
                OnPropertyChanged(nameof(Content));
            }
        }
        #endregion
    }
}
