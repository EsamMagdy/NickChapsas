namespace ServiceLifetime
{
    public interface ITransientService
    {
        public string Name { get; set; }
        string GetName(string name);
    }
}
