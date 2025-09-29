public interface INavigationState
{
    string NavChat { get; set; }
    string NavHistory { get; set; }
}

public class NavigationState : INavigationState
{
    public string NavChat { get; set; } = "Chat Message";
    public string NavHistory { get; set; } = "History";
}
