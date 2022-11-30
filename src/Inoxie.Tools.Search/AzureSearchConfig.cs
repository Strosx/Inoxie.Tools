namespace Inoxie.Tools.Search;

public class AzureSearchConfig
{
    public const string Key = "AzureSearchConfig";

    public string ApiKey { get; set; }

    public ICollection<AzureSearchIndex> Indexes { get; set; }

    public class AzureSearchIndex
    {
        public string Name { get; set; }

        public string IndexUrl { get; set; }
    }
}