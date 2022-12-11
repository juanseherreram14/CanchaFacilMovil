using System.Reflection;

namespace CanchaFacilMovil.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ReservaPage : ContentPage
{

    public ReservaPage()
    {
        InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));


    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Reserva note)
            File.WriteAllText(note.Filename,"Rentado por: " + TextEditor.Text + " / En la Cancha: " + TextEditor1.Text + "/  Deporte:  " + TextEditor2.Text);
           

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Reserva note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        Models.Reserva noteModel = new Models.Reserva();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Fecha = File.GetCreationTime(fileName);
            noteModel.Nombre = File.ReadAllText(fileName);
            noteModel.Cancha = File.ReadAllText(fileName);
            noteModel.Deporte = File.ReadAllText(fileName);

        }

        BindingContext = noteModel;
    }
    public string ItemId
    {
        set { LoadNote(value); }
    }
}