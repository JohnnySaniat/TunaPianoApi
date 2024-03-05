namespace TunaPianoApi.Models;
public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public string Album { get; set; }
    public float Length { get; set; }

    public ICollection<Genre> Genres { get; set; }
};


