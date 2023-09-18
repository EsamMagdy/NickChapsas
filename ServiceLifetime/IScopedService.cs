namespace ServiceLifetime
{
    public interface IScopedService
    {
        public string Name { get; set; }

        string GetName(string name);
    }
}
