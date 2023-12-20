using Newtonsoft.Json;

namespace ContatusApiConsole.Models
{
    public class Linha
    {
        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("cells")]
        public List<Cell> Cells { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("totalizer")]
        public bool Totalizer { get; set; }

        [JsonProperty("parentId")]
        public string ParentId { get; set; }
    }
}