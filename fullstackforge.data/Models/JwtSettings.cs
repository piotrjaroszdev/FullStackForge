using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fullstackforge.data.Models
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpiryMinutes { get; set; }
    }

}
