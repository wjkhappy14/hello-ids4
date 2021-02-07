using IdentityServer4.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skoruba.IdentityServer4.Admin.EntityFramework
{
    public class ApiSecret : Secret
    {
        public ApiSecret() { }

        public int ApiResourceId { get; set; }
        public ApiResource ApiResource { get; set; }
    }
}
