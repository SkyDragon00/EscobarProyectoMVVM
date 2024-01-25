using EscobarProyectoMVVM.EscobarModels;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EscobarProyectoMVVM.EscobarViewsModels
{
    class EscobarNotesViewModels : IQueryAttributable
    {
        public ObservableCollection<EscobarViewsModels.EscobarNoteViewModels> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }

        public EscobarNotesViewModels()
        {
            AllNotes = new ObservableCollection<EscobarViewsModels.EscobarNoteViewModels>(EscobarModels.EscobarNotes.LoadAll().Select(n => new EscobarNoteViewModels(n)));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<EscobarViewsModels.EscobarNoteViewModels>(SelectNoteAsync);
        }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(EscobarViews.EscobarNotePage));
        }

        private async Task SelectNoteAsync(EscobarViewsModels.EscobarNoteViewModels note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(EscobarViews.EscobarNotePage)}?load={note.Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                EscobarNoteViewModels matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                EscobarNoteViewModels matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                {
                    matchedNote.Reload();
                    AllNotes.Move(AllNotes.IndexOf(matchedNote), 0);
                }

                // If note isn't found, it's new; add it.
                else
                    AllNotes.Insert(0, new EscobarNoteViewModels(EscobarModels.EscobarNotes.Load(noteId)));
            }
        }
    }
}
