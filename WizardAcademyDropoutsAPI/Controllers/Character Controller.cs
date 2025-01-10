// namespace WizardAcademyDropouts.Controllers;

// using Services;
// using WizardAcademyDropouts.Domain.Entities;

// public class CharacterController
// {
//     private CharacterService _service;
    
//     public CharacterController(CharacterService service)
//     {
//         _service = service;
//     }

//     public Task<List<Character>> GetAll() => _service.GetAll();

//     public static void MapCharacterEndpoints(WebApplication app)
//     {
//         app.MapGet("/characters", GetAll);
//         app.MapGet("/characters/{id}", _service.GetById);
//         app.MapPost("/characters", _service.AddOrUpdate);
//     }
// }
