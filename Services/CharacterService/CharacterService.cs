namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character> { };
        private readonly RPGContext _context;
        private readonly IMapper _mapper;

        public CharacterService(RPGContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<ReadCharacterDto>>> List()
        {
            var serviceResponse = new ServiceResponse<List<ReadCharacterDto>>();

            try
            {
                var characters = await _context.Characters.Select(c => _mapper.Map<ReadCharacterDto>(c)).ToListAsync();
                
                if (characters.Any() is false)
                    throw new Exception($"Character is not yet created.");
                
                serviceResponse.Data = characters;
                serviceResponse.Message = "Characters fetched successfully.";
            }
            catch(Exception error)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = error.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ReadCharacterDto>>> Create(CreateCharacterDto createCharacter)
        {
            var serviceResponse = new ServiceResponse<List<ReadCharacterDto>>();
            var character = _mapper.Map<Character>(createCharacter);

            try
            {
                // if (await _context.Characters.AnyAsync())
                //     character.Id = await _context.Characters.MaxAsync(c => c.Id) + 1;

                await _context.Characters.AddAsync(character);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "Character created successfully.";
            }
            catch(Exception error)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = error.Message;
            }
            
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<ReadCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<ReadCharacterDto>> Read(int id)
        {
            var serviceResponse = new ServiceResponse<ReadCharacterDto>();

            try
            {
                var character = await _context.Characters.FindAsync(id);
                
                if (character is null)
                    throw new Exception($"Can't find a Character with an ID of '{id}'");
                
                serviceResponse.Data = _mapper.Map<ReadCharacterDto>(character);
                serviceResponse.Message = "Character fetched successfully.";
            }
            catch(Exception error)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = error.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ReadCharacterDto>>> Update(UpdateCharacterDto updateCharacter)
        {
            var serviceResponse = new ServiceResponse<List<ReadCharacterDto>>();

            try
            {
                var character = await _context.Characters.FindAsync(updateCharacter.Id);

                if (character is null)
                    throw new Exception($"Can't find a Character with an ID of '{updateCharacter.Id}'");

                _mapper.Map(updateCharacter, character);

                await _context.SaveChangesAsync();
                serviceResponse.Message = "Character updated successfully.";
            }
            catch(Exception error)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = error.Message;
            }

            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<ReadCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<ReadCharacterDto>>> Delete(int id)
        {
            var serviceResponse = new ServiceResponse<List<ReadCharacterDto>>();

            try
            {
                var character = await _context.Characters.FindAsync(id);
                
                if (character is null)
                    throw new Exception($"Can't find a Character with an ID of '{id}'");
                
                _context.Characters.Remove(character);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "Character deleted successfully.";
            }
            catch(Exception error)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = error.Message;
            }
            
            serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<ReadCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }
    }
}