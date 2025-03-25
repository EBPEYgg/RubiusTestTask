using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория для работы с музыкальными произведениями.
    /// </summary>
    public interface IMusicRepository
    {
        Task<IEnumerable<Musician>> GetMusiciansWithAlbumsAsync();

        Task<IEnumerable<Track>> GetTracksByMusicianAsync(long musicianId);

        Task<IEnumerable<Track>> GetTracksByAlbumAsync(long albumId);

        Task RateTrackAsync(long trackId, int rating);

        Task MarkTrackAsListenedAsync(long trackId);

        Task AddTrackToFavoritesAsync(long trackId);
    }
}