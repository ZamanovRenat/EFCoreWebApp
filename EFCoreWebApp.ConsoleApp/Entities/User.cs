namespace EFCoreWebApp.ConsoleApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int CompanyId { get; set; }      // внешний ключ
        public virtual Company? Company { get; set; }    // навигационное свойство
    }
}
