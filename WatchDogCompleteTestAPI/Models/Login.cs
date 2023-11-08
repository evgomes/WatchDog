using WatchDog.src.Attributes;

namespace WatchDogCompleteTestAPI.Models
{
    public class Login
    {
        public string? Username { get; set; }

        [SensitiveString]
        public string? Password { get; set; }
    }
}
