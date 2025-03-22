using Microsoft.AspNetCore.Mvc;
using RubiusTestTask.Domain.Interfaces;

namespace RubiusTestTask.Controllers
{
    [ApiController]
    [Route("api/v1/music")]
    public class MusicController : Controller
    {
        private readonly IMusicService _musicService;

        public MusicController(IMusicService musicService)
        {
            _musicService = musicService;
        }

        // GET: api/v1/music/tree
        [HttpGet("tree")]
        public async Task<IActionResult> GetMusicTree()
        {
            var musicians = await _musicService.GetMusiciansWithAlbumsAsync();
            return Ok(musicians);
        }

        // GET: api/v1/music/tracks/musician/{id}
        [HttpGet("tracks/musician/{id}")]
        public async Task<IActionResult> GetTracksByMusician(int id)
        {
            var tracks = await _musicService.GetTracksByMusicianAsync(id);
            return Ok(tracks);
        }

        // GET: api/v1/music/tracks/album/{id}
        [HttpGet("tracks/album/{id}")]
        public async Task<IActionResult> GetTracksByAlbum(int id)
        {
            var tracks = await _musicService.GetTracksByAlbumAsync(id);
            return Ok(tracks);
        }

        // POST: api/v1/music/rate/{id}?rating={rating}
        [HttpPost("rate/{id}")]
        public async Task<IActionResult> RateTrack(int id, [FromQuery] int rating)
        {
            await _musicService.RateTrackAsync(id, rating);
            return Ok();
        }

        // POST: api/v1/music/listened/{id}
        [HttpPost("listened/{id}")]
        public async Task<IActionResult> MarkListened(int id)
        {
            await _musicService.MarkTrackAsListenedAsync(id);
            return Ok();
        }

        // POST: api/v1/music/favorite/{id}
        [HttpPost("favorite/{id}")]
        public async Task<IActionResult> AddFavorite(int id)
        {
            await _musicService.AddTrackToFavoritesAsync(id);
            return Ok();
        }
    }
}