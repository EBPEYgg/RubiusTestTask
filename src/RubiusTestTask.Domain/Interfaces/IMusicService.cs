using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Domain.Interfaces
{
    public interface IMusicService
    {
        Task<IEnumerable<Musician>> GetMusiciansWithAlbumsAsync();

        Task<IEnumerable<Track>> GetTracksByMusicianAsync(int musicianId);

        Task<IEnumerable<Track>> GetTracksByAlbumAsync(int albumId);

        Task RateTrackAsync(int trackId, int rating);

        Task MarkTrackAsListenedAsync(int trackId);

        Task AddTrackToFavoritesAsync(int trackId);
    }
}