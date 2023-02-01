using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FoodDeliveryAPI
{
    public class JwtConfiguration
    {
        private static IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

        public static int Lifetime = configuration.GetSection("JwtConfiguration").GetValue<int>("LifetimeMinutes"); // время жизни токена
        public static string Issuer = configuration.GetSection("JwtConfiguration").GetValue<string>("Issuer"); // издатель токена
        public static string Audience = configuration.GetSection("JwtConfiguration").GetValue<string>("Audience"); // потребитель токена
        private static string Key = configuration.GetSection("JwtConfiguration").GetValue<string>("Key");   // ключ для шифрации

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
