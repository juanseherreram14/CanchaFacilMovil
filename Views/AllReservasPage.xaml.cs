using System.Reflection;

namespace CanchaFacilMovil.Views;

public partial class AllReservasPage : ContentPage
{
    public AllReservasPage()
    {
        InitializeComponent();

        BindingContext = new Models.AllReservas();
    }

    protected override void OnAppearing()
    {
        ((Models.AllReservas)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ReservaPage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (Models.Reserva)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(ReservaPage)}?{nameof(ReservaPage.ItemId)}={note.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }
}