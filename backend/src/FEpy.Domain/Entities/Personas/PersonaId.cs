public record PersonaId(Guid Value)
{
    public static PersonaId  New() => new(Guid.NewGuid());
}