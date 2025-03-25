using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса для работы с музыкой.
    /// </summary>
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