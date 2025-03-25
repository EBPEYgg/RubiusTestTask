using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RubiusTestTask.DataAccess.Data;
using RubiusTestTask.Domain.Interfaces;
using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.DataAccess.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly MusicDbContext _context;

        private readonly IMapper _mapper;

        public MusicRepository(MusicDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Musician>> GetMusiciansWithAlbumsAsync()
        {
            var musicianEntities = await _context.Musicians
                .Include(m => m.Albums)
                .ThenInclude(a => a.Tracks)
                .AsNoTracking()
                .ToListAsync();

            if (musicianEntities == null || !musicianEntities.Any())
            {
                throw new KeyNotFoundException("No musicians found.");
            }

            return musicianEntities.Select(entity => _mapper.Map<Musician>(entity));
        }

        public async Task<IEnumerable<Track>> GetTracksByMusicianAsync(long musicianId)
        {
            var albumEntities = await _context.Albums
                .Where(a => a.MusicianId == musicianId)
                .Include(a => a.Tracks)
                .AsNoTracking()
                .ToListAsync();

            var tracks = albumEntities.SelectMany(a => a.Tracks).ToList();

            if (tracks == null || !tracks.Any())
            {
                throw new KeyNotFoundException($"No tracks found for musician with id={musicianId}.");
            }

            return tracks.Select(trackEntity => _mapper.Map<Track>(trackEntity));
        }

        public async Task<IEnumerable<Track>> GetTracksByAlbumAsync(long albumId)
        {
            var tracks = await _context.Tracks
                .Where(t => t.AlbumId == albumId)
                .ToListAsync();

            if (tracks == null || !tracks.Any())
            {
                throw new KeyNotFoundException($"No tracks found for album with id={albumId}.");
            }

            return tracks.Select(trackEntity => _mapper.Map<Track>(trackEntity)) ?? new List<Track>();
        }

        public async Task RateTrackAsync(long trackId, int rating)
        {
            var trackEntity = await _context.Tracks.FindAsync(trackId);
            if (trackEntity == null)
            {
                throw new KeyNotFoundException($"Track with id={trackId} not found.");
            }

            trackEntity.Rating = rating; // не проверяет ограничения
            await _context.SaveChangesAsync();
        }

        public async Task MarkTrackAsListenedAsync(long trackId)
        {
            var trackEntity = await _context.Tracks.FindAsync(trackId);
            if (trackEntity == null)
            {
                throw new KeyNotFoundException($"Track with id={trackId} not found.");
            }

            trackEntity.IsListened = true;
            await _context.SaveChangesAsync();
        }

        public async Task AddTrackToFavoritesAsync(long trackId)
        {
            var trackEntity = await _context.Tracks.FindAsync(trackId);
            if (trackEntity == null)
            {
                throw new KeyNotFoundException($"Track with id={trackId} not found.");
            }

            trackEntity.IsFavorite = true;
            await _context.SaveChangesAsync();
        }
    }
}