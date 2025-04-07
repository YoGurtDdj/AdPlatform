namespace AdPlatform.Data
{
    public class Platform
    {
        public string Name { get; set; }
        public List<string> Locations { get; set; } = new List<string>();
        public HashSet<string> AllLocsForPlatform { get; set; } = new HashSet<string>();
    }
}
