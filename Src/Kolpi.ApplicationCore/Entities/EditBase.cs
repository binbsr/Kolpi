namespace Kolpi.ApplicationCore.Entities;
public class EditBase<TKey> : BaseEntity<TKey>
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public string? ModifiedBy { get; set; }

    public EditBase<TKey> AddCreatedStamps(string createdBy)
    {
        CreatedBy = createdBy;
        CreatedAt = DateTime.UtcNow;
        return this;
    }

    public EditBase<TKey> AddModifiedStamps(string modifiedBy)
    {
        ModifiedBy = modifiedBy;
        ModifiedAt = DateTime.UtcNow;
        return this;
    }
}
