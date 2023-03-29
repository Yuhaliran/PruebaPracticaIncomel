using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Proyecto1.Models
{

    [Table("persona")] 
    public class Persona
    {
        [Key] 
        [Column("idPersona")]
        public int IdPersona { get; set; }

        [Column("idTipoUsuario")] 
        public int idTipoUsuario { get; set; }

        [Column("nombres")] 
        public string nombres { get; set; }

        [Column("apellidos")]
        public string apellidos { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("nacimiento")]
        public DateTime nacimiento { get; set; }

        [Column("pass")]
        public string pass { get; set; }

        [Column("dpi")]
        public long dpi { get; set; }

        [Column("numHijos")]
        public int numHijos { get; set; }

        [Column("salarioBase")]
        public decimal salarioBase { get;}

        [Column("fechaCreacion")]
        public DateTime fechaCreacion { get; set; }

        [Column("usuarioLogin")]
        public string usuarioLogin{ get;set; }

        [Column("puedeLogear")]
        public bool puedeLogear { get; set; }   
    }


public static class PersonaEndpoints
{
	public static void MapPersonaEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Persona", () =>
        {
            return new [] { new Persona() };
        })
        .WithName("GetAllPersonas");

        routes.MapGet("/api/Persona/{id}", (int id) =>
        {
            //return new Persona { ID = id };
        })
        .WithName("GetPersonaById");

        routes.MapPut("/api/Persona/{id}", (int id, Persona input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdatePersona");

        routes.MapPost("/api/Persona/", (Persona model) =>
        {
            //return Results.Created($"/Personas/{model.ID}", model);
        })
        .WithName("CreatePersona");

        routes.MapDelete("/api/Persona/{id}", (int id) =>
        {
            //return Results.Ok(new Persona { ID = id });
        })
        .WithName("DeletePersona");
    }
}}
