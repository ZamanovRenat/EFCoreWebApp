namespace EFCoreWebApp.Core.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }      // внешний ключ
        public Company Company { get; set; }    // навигационное свойство
    }
}
