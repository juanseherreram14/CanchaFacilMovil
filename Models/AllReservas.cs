using System.Collections.ObjectModel;

namespace CanchaFacilMovil.Models;

internal class AllReservas
{
    public ObservableCollection<Reserva> Notes { get; set; } = new ObservableCollection<Reserva>();

    public AllReservas() =>
        LoadNotes();

    public void LoadNotes()
    {
        Notes.Clear();

        // Get the folder where the notes are stored.
        string appDataPath = FileSystem.AppDataDirectory;

        // Use Linq extensions to load the *.notes.txt files.
        IEnumerable<Reserva> reservas = Directory

                                    // Select the file names from the directory
                                    .EnumerateFiles(appDataPath, "*.notes.txt")

                                    // Each file name is used to create a new Note
                                    .Select(filename => new Reserva()
                                    {
                                        Filename = filename,
                                        Nombre = File.ReadAllText(filename),
                                        Cancha=File.ReadAllText(filename),
                                        Deporte = File.ReadAllText(filename),
                                        Fecha = File.GetCreationTime(filename)
                                    })

                                    // With the final collection of notes, order them by date
                                    .OrderBy(reserva => reserva.Fecha);

        // Add each note into the ObservableCollection
        foreach (Reserva reserva in reservas)
            Notes.Add(reserva);
    }
}