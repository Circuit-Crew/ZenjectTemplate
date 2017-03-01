namespace SecretCrush.Zenject
{
    public enum ObjectStates
    {
        None, // "none" state needs to exist so the object can spawn a real state handler on construction
        DefaultState
    }
}