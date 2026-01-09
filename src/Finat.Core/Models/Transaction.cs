using Finat.Core.Enums;

namespace Finat.Core.Models;

public class Transaction
{
    public long Id { get; init; }
    public string Title { get; set; } = string.Empty;

    public DateTime CreatAt { get; init; } = DateTime.UtcNow;
    public DateTime? PaidOrReceivedAt { get; set; }

    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;

    public decimal Amount { get; set; }

    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public string UserId { get; set; } =  string.Empty;
}
