using System;
using System.Globalization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SecretStoreAuthService
{
    public class Configuration
    {
        public static AAD GetAadConfiguration()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();
            
            AAD aadConfig = new();
            configuration.Bind(nameof(AAD),aadConfig);
            
            aadConfig.Authority = string.Format(CultureInfo.InvariantCulture, 
                aadConfig.Instance, aadConfig.TenantId);
            return aadConfig;
        }
    }

    public class AAD   
    {
        public string Instance {get; set;} 
        public string TenantId {get; set;}
        public string ClientId {get; set;}
        public string Authority { get; set; }
            

        public string ClientSecret {get; set;}
        public string BaseAddress {get; set;}
        public string ResourceID {get; set;}
        
        
    }
}