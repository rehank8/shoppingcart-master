using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartApp.Models.Utility
{
    public class JwtHelper
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
