using Microsoft.Extensions.Logging;
using RubiusTestTask.Domain.Interfaces;
using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Application.Services
{
    public class MusicService : IMusicService
    {
        private readonly ILogger<MusicService> _logger;

        private readonly IMusicRepository _repository;

        public MusicService(IMusicRepository repository,
                            ILogger<MusicService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<Musician>> GetMusiciansWithAlbumsAsync()
        {
            _logger.LogInformation("Retrieving all musicians from the database.");
            var musicians = await _repository.GetMusiciansWithAlbumsAsync();
            _logger.LogInformation("Successfully retrieved {Count} musicians.", musicians.Count());
            return musicians;
        }

        public async Task<IEnumerable<Track>> GetTracksByMusicianAsync(long musicianId)
        {
            _logger.LogInformation("Retrieving tracks with musician id={id}.", musicianId);
            var tracks = await _repository.GetTracksByMusicianAsync(musicianId);

            if (tracks == null)
            {
                _logger.LogWarning("Tracks with musician id={id} not found.", musicianId);
                throw new KeyNotFoundException($"Tracks with musician id={musicianId} not found.");
            }

            _logger.LogInformation("Successfully retrieved tracks with musician id={id}.", musicianId);
            return tracks;
        }

        public async Task<IEnumerable<Track>> GetTracksByAlbumAsync(long albumId)
        {
            _logger.LogInformation("Retrieving tracks by album with id={id}.", albumId);
            var tracks = await _repository.GetTracksByAlbumAsync(albumId);

            if (tracks == null)
            {
                _logger.LogWarning("Tracks by album with id={id} not found.", albumId);
                throw new KeyNotFoundException($"Tracks by album with id={albumId} not found.");
            }

            _logger.LogInformation("Successfully retrieved tracks by album with id={id}.", albumId);
            return tracks;
        }

        public async Task RateTrackAsync(long trackId, int rating)
        {
            _logger.LogInformation("Rating a track with id={0} as {1}.", trackId, rating);
            await _repository.RateTrackAsync(trackId, rating);
            _logger.LogInformation("Successfully rating of track with id={0} rated as {1}.", trackId, rating);
        }

        public async Task MarkTrackAsListenedAsync(long trackId)
        {
            _logger.LogInformation("Marking a track with id={0} as listened.", trackId);
            await _repository.MarkTrackAsListenedAsync(trackId);
            _logger.LogInformation("Track with id={0} has been successfully marked as listened.", trackId);
        }

        public async Task AddTrackToFavoritesAsync(long trackId)
        {
            _logger.LogInformation("Adding a track with id={0} to favorites.", trackId);
            await _repository.AddTrackToFavoritesAsync(trackId);
            _logger.LogInformation("Successfully adding track with id={0} added to favorites.", trackId);
        }
    }
}