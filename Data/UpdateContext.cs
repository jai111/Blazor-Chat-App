namespace BlazorApp.Data
{
    public class UpdateContext
    {
        public bool Update { get; set; }
        public Action<Boolean> SetUpdate { get; set; }
    }
}