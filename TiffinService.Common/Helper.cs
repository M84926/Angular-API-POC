using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularPOC.Common
{
    public interface IHelper
    {
        string JwtKey { get; }
        string JwtAudience { get; }
        string JwtIssuer { get; }
        string JwtExpireTime { get; }
    }

    public class Helper : IHelper
    {
        public IConfiguration Configuration { get; }

        public Helper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string JwtKey => Configuration["Tokens:key"];
        public string JwtAudience => Configuration["Tokens:audience"];
        public string JwtIssuer => Configuration["Tokens:issuer"];
        public string JwtExpireTime => Configuration["Tokens:expiretime"];

    }
}
