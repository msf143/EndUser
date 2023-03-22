
namespace API.Options
{
    public class ApiOptions
    {
        public ApiOptions(string value)
        {
            CustomSetting = value;
        }
        public string CustomSetting { get; set; }
    }
}