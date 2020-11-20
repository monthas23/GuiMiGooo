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

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }


    }
}