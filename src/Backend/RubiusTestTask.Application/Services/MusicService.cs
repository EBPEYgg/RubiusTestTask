using NLog;
using RubiusTestTask.Domain.Interfaces;
using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Application.Services
{
    /// <summary>
    /// Сервис для работы с музыкой.
    /// </summary>
    public class MusicService : IMusicService
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        private readonly IMusicRepository _repository;

        public MusicService(IMusicRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Musician>> GetMusiciansWithAlbumsAsync()
        {
            _logger.Info("Retrieving all musicians from the database.");
            var musicians = await _repository.GetMusiciansWithAlbumsAsync();
            _logger.Info("Successfully retrieved {Count} musicians.", musicians.Count());
            return musicians;
        }

        public async Task<IEnumerable<Track>> GetTracksByMusicianAsync(long musicianId)
        {
            _logger.Info("Retrieving tracks with musician id={id}.", musicianId);
            var tracks = await _repository.GetTracksByMusicianAsync(musicianId);

            if (tracks == null)
            {
                _logger.Warn("Tracks with musician id={id} not found.", musicianId);
                throw new KeyNotFoundException($"Tracks with musician id={musicianId} not found.");
            }

            _logger.Info("Successfully retrieved tracks with musician id={id}.", musicianId);
            return tracks;
        }

        public async Task<IEnumerable<Track>> GetTracksByAlbumAsync(long albumId)
        {
            _logger.Info("Retrieving tracks by album with id={id}.", albumId);
            var tracks = await _repository.GetTracksByAlbumAsync(albumId);

            if (tracks == null)
            {
                _logger.Warn("Tracks by album with id={id} not found.", albumId);
                throw new KeyNotFoundException($"Tracks by album with id={albumId} not found.");
            }

            _logger.Info("Successfully retrieved tracks by album with id={id}.", albumId);
            return tracks;
        }

        public async Task RateTrackAsync(long trackId, int rating)
        {
            _logger.Info("Rating a track with id={0} as {1}.", trackId, rating);
            await _repository.RateTrackAsync(trackId, rating);
            _logger.Info("Successfully rating of track with id={0} rated as {1}.", trackId, rating);
        }

        public async Task MarkTrackAsListenedAsync(long trackId)
        {
            _logger.Info("Marking a track with id={0} as listened.", trackId);
            await _repository.MarkTrackAsListenedAsync(trackId);
            _logger.Info("Track with id={0} has been successfully marked as listened.", trackId);
        }

        public async Task AddTrackToFavoritesAsync(long trackId)
        {
            _logger.Info("Adding a track with id={0} to favorites.", trackId);
            await _repository.AddTrackToFavoritesAsync(trackId);
            _logger.Info("Successfully adding track with id={0} added to favorites.", trackId);
        }
    }
}