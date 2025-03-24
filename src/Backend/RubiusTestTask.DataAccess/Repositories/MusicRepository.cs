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

            return musicianEntities.Select(MapMusician);
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

        }

            return tracks.Select(trackEntity => _mapper.Map<Track>(trackEntity));
        }

        public async Task<IEnumerable<Track>> GetTracksByAlbumAsync(long albumId)
        {
            var albumEntity = await _context.Albums
                .Include(a => a.Tracks)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == albumId);

            if (albumEntity == null || albumEntity.Tracks == null)
            {
                return new List<Track>();
            }

            return albumEntity.Tracks.Select(MapTrack);
        }

            return albumEntity.Tracks?.Select(entity => _mapper.Map<Track>(entity)) ?? new List<Track>();
        }

        public async Task RateTrackAsync(long trackId, int rating)
        {
            var trackEntity = await _context.Tracks.FindAsync(trackId);
            if (trackEntity != null)
            {
                trackEntity.Rating = rating;
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkTrackAsListenedAsync(long trackId)
        {
            var trackEntity = await _context.Tracks.FindAsync(trackId);
            if (trackEntity != null)
            {
                trackEntity.IsListened = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTrackToFavoritesAsync(long trackId)
        {
            var trackEntity = await _context.Tracks.FindAsync(trackId);
            if (trackEntity != null)
            {
                trackEntity.IsFavorite = true;
                await _context.SaveChangesAsync();
            }
        }

        #region Mapping Helpers
        private Musician MapMusician(MusicianEntity entity)
        {
            return new Musician
            {
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age,
                Genre = entity.Genre ?? string.Empty,
                CareerStartYear = entity.CareerStartYear,
                Albums = entity.Albums?.Select(MapAlbum).ToList() ?? new List<Album>()
            };
        }

        private Album MapAlbum(AlbumEntity entity)
        {
            return new Album
            {
                Id = entity.Id,
                Name = entity.Name,
                ReleaseYear = entity.ReleaseYear,
                Tracks = entity.Tracks?.Select(MapTrack).ToList() ?? new List<Track>()
            };
        }

        private Track MapTrack(TrackEntity entity)
        {
            return new Track
            {
                Id = entity.Id,
                Name = entity.Name,
                Duration = entity.Duration,
                IsFavorite = entity.IsFavorite,
                IsListened = entity.IsListened,
                Rating = entity.Rating
            };
        }
        #endregion
    }
}