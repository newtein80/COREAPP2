using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace COREAPP2.Persistence.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

        #region+ https://hk.saowen.com/a/26891139700db6c088cddb36c19e324a339492553e904e60e613e83c7d04ffcd : Must be executed "Migration"
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
        #endregion
    }
}
