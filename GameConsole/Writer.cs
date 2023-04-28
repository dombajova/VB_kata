namespace GameConsole;

public static class Writer
{
    private static Action<string> _action;  
        
    public static void Write(string message)
    {
        _action(message);
    }

    public static void SetWriter(Action<string> action)
    {
        _action = action;
    }
}