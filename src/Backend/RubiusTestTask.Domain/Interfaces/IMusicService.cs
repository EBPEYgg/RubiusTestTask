using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Domain.Interfaces
{
    public interface IMusicService
    {
        Task<IEnumerable<Musician>> GetMusiciansWithAlbumsAsync();

        Task<IEnumerable<Track>> GetTracksByMusicianAsync(long musicianId);

        Task<IEnumerable<Track>> GetTracksByAlbumAsync(long albumId);

        Task RateTrackAsync(long trackId, int rating);

        Task MarkTrackAsListenedAsync(long trackId);

        Task AddTrackToFavoritesAsync(long trackId);
    }
}