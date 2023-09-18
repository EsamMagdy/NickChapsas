namespace ServiceLifetime
{
    public interface ISingletonService
    {
        public string Name { get; set; }
        string GetName(string name);
    }
}
