namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, ReadCharacterDto>();
            CreateMap<CreateCharacterDto, Character>();
            CreateMap<UpdateCharacterDto, Character>();
        }
    }
}