

using System.Text.Json.Serialization;

namespace Natural_API.Resources
{
    public class LoginResponse
    {
        [JsonPropertyName("FirstName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? FirstName { get; set; }

        [JsonPropertyName("LastName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? LastName { get; set; }

       
        public string? Message { get; set; }
        public int StatusCode { get; set; }
    }
}
