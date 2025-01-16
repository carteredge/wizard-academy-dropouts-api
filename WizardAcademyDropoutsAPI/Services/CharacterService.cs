namespace WizardAcademyDropouts.Services;

using System.Security.Claims;
using AutoMapper;
using Domain;
using Domain.Entities;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CharacterService
{
    private DropoutsDBContext _context;
    private IMapper _mapper;

    public CharacterService(DropoutsDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddOrUpdate([FromBody] CharacterDTO characterDTO, ClaimsPrincipal claimsPrincipal)
    {
        // TODO: User handling if update
        var character = _mapper.Map<Character>(characterDTO);
        
        if (!character.IsNew)
        {
            _context.Items.RemoveRange(_context.Items.Where(i => i.CharacterId == character.Id));
        }
        character.FailureId = character.Failure?.Id ?? 0;
        character.KnackId = character.Knack?.Id ?? 0;
        character.UserId = int.Parse(claimsPrincipal.Claims.First(claim => claim.Type == "sub").Value);
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();
        return;
    }

    public async Task<IEnumerable<CharacterListItemDTO>> GetAll()
    {
        // TODO: User handling
        var characters = await _context.Characters.ToListAsync();
        return characters.Select(c => _mapper.Map<CharacterListItemDTO>(c));
    }

    public async Task<CharacterDTO?> GetById(int id)
    {
        // TODO: User handling
        var character = await _context.Characters
            .Include(c => c.Inventory)
            .SingleOrDefaultAsync(c => c.Id == id);
        return _mapper.Map<CharacterDTO>(character);
            // ?? NotFound($"No character with ID {id} found.");
    }
}

public static class CharacterServiceExtensions {
    public static IEndpointRouteBuilder MapCharacterEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/characters", (CharacterService service) => service.GetAll());
        app.MapGet("/characters/{id}", (CharacterService service, int id) => service.GetById(id));
        app.MapPost("/characters",
            (CharacterService service, CharacterDTO characterDTO, ClaimsPrincipal claimsPrincipal) =>
                service.AddOrUpdate(characterDTO, claimsPrincipal)).RequireAuthorization();
        return app;
    }
}
