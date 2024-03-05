namespace CleanArchitecture.Domain.Common
{
    /// <summary>
    /// Modelo base para todas las entidades
    /// Todas las entidades heredaran de este modelo
    /// Todas las entidades tienen un identificador (Clave primaria): Id
    /// </summary>
    public class BaseDomainModel
    {
        public int Id { get; set; }
    }
}
