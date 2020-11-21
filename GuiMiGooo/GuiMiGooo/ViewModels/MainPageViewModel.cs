using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            SelectedNoteChangedCommand = new Command(async () =>

            {
                var detailVM = new DetalPageViewModel(SelectedNote);

                var detailPage = new DetailPage();

                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            
            });

            EraseCommand = new Command(() =>
            {
                if (AllNotes.Contains(TheNote))
                    AllNotes.Remove(theNote);

                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
           {
               if(!AllNotes.Contains(TheNote))
                   AllNotes.Add(TheNote);
                   
               TheNote = string.Empty;

           });

        }

        // public ObservableCollection<string> allNotes;
        public ObservableCollection<string> AllNotes { get; }


        public event PropertyChangedEventHandler PropertyChanged;

        string theNote;

        public string TheNote
        {

            get => theNote;
            set
            {
                theNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        string selectedNote;

        public string SelectedNote
        {

            get => selectedNote;
            set
            {
                selectedNote = value;

                var args = new PropertyChangedEventArgs(nameof(TheNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

        public Command SelectedNoteChangedCommand { get; }
        


    }
}