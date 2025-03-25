using AutoMapper;
using RubiusTestTask.DataAccess.Entities;
using RubiusTestTask.Domain.Models;

namespace RubiusTestTask.Application.MappingProfiles
{
    /// <summary>
    /// Профиль маппинга для AutoMapper.
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Создает новый экземпляр класса <see cref="MappingProfile"/>.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<MusicianEntity, Musician>()
                .ForMember(dest => dest.Albums, opt => opt.MapFrom(src => src.Albums));

            CreateMap<AlbumEntity, Album>()
                .ForMember(dest => dest.Tracks, opt => opt.MapFrom(src => src.Tracks));

            CreateMap<TrackEntity, Track>();
        }
    }
}