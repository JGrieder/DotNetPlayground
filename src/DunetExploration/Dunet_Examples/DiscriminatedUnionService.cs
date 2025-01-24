using Microsoft.Extensions.Logging;

namespace DunetExploration.Dunet_Examples;

public class DiscriminatedUnionService
{
    public static Option<TReturn> GetSomethingOrNothing<TReturn>(bool @switch)
        where TReturn : notnull, new()
    {
        if (@switch)
        {
            return new Option<TReturn>.Some(new TReturn());
        }
        
        return new Option<TReturn>.None();
    }

    public static async ValueTask<Result<Item, Message>> GetItemAsync(
        string name,
        CancellationToken cancellationToken = default)
    {
        await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);
        
        if (string.IsNullOrWhiteSpace(name))
            return new Result<Item, Message>.Error(new EventId(1, "Name.NullOrEmpty"), new Message("Name is required"));

        return new Result<Item, Message>.Success(new Item(Guid.Empty, "Test", 1));
    }
}

public record Item(Guid Id, string Name, int Quantity);
public record Message(string Value);