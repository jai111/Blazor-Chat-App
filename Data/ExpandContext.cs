namespace BlazorApp.Data
{
    public class ExpandContext
    {
        public bool Expanded { get; set; }
        public Action<Boolean> SetExpanded { get; set; }
    }
}