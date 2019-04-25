namespace PrantiksmeApp.Models.Contracts
{
    public interface IDeletable
    {
        bool IsDeleted { get; set; }
        bool Delete();

    }
}
