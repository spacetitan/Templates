public interface IInteractable
{
    public string interactPrompt { get; }
    public float interactTime { get; }
    public bool Interact(Interactor interactor);
}
