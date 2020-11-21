using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GuiMiGooo.ViewModels
{
    public class DetalPageViewModel : INotifyPropertyChanged
    {
        private string selectedNote;


        public string SelectedNote
        {

            get => selectedNote;
            set
            {
                selectedNote = value;

                var args = new PropertyChangedEventArgs(nameof(SelectedNote));

                PropertyChanged?.Invoke(this, args);
            }
        }

        public DetalPageViewModel()
        {
            //Content = new StackLayout
            //{
            //    Children = {
            //        new Label { Text = "Welcome to Xamarin.Forms!" }
            //    }
            //};
        }

        public DetalPageViewModel(string selectedNote)
        {
            this.selectedNote = "Welcome to GuiMiGomma  " +  selectedNote;
            GoBackHomePage = new Command( async () =>
            {
                await Application.Current.MainPage.Navigation.PopModalAsync();
            
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public Command GoBackHomePage { get; }
    }
}