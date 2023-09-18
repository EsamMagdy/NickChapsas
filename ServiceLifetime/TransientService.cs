namespace ServiceLifetime
{
    public class TransientService : ITransientService
    {
        public string Name { get; set; }

        public string GetName(string name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                Name = name;
                return Name;
            }

            return "Is Initial Before";
        }
    }
}
