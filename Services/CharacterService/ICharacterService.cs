namespace dotnet_rpg.Services.CharacterService
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<ReadCharacterDto>>> List();
        Task<ServiceResponse<List<ReadCharacterDto>>> Create(CreateCharacterDto createCharacter);
        Task<ServiceResponse<ReadCharacterDto>> Read(int id);
        Task<ServiceResponse<List<ReadCharacterDto>>> Update(UpdateCharacterDto updateCharacter);
        Task<ServiceResponse<List<ReadCharacterDto>>> Delete(int id);
    }
}
