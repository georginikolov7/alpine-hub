namespace AlpineHub.Data.Models.Contracts
{
    public interface ISoftDeletable
    {
        bool IsDeleted { get; set; }
    }
}
