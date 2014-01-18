namespace MVC2OpenID.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using RelyingPartyLogic;

    public class AccountInfoModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public IList<AuthorizedApp> AuthorizedApps { get; set; }

        public IList<AuthenticationToken> AuthenticationTokens { get; set; }

        public class AuthorizedApp
        {
            public string Token { get; set; }

            public string AppName { get; set; }
        }
    }
}
