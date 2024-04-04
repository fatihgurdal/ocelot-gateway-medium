using Microsoft.AspNetCore.SignalR;

namespace BasketService.Hubs;
public class UserConnection
{
    public string UserId { get; set; }
}
public class BaskerHub: Hub
{
    public async Task JoinSelfHub(UserConnection userConnection)
    {
        var userId = userConnection.UserId;
        await Groups.AddToGroupAsync(Context.ConnectionId, userId.ToString()).ConfigureAwait(false);
    }
}