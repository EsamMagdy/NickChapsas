namespace ServiceLifetime
{
    public class SingletonService : ISingletonService
    {
        public string Name { get; set; }

        public string GetName(string name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = name;
                return Name;
            }

            return "Initial Before";

        }
    }
}
