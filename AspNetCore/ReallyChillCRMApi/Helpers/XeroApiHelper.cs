﻿using System;
using Xero.Api.Core;
using ReallyChillCRMApi.TokenStores;
using Xero.Api;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using IMvcAuthenticator = ReallyChillCRMApi.Authenticators.IMvcAuthenticator;
using PartnerMvcAuthenticator = ReallyChillCRMApi.Authenticators.PartnerMvcAuthenticator;
using PublicMvcAuthenticator = ReallyChillCRMApi.Authenticators.PublicMvcAuthenticator;

namespace ReallyChillCRMApi.Helpers
{
    public static class XeroApiHelper
    {
        private static IMvcAuthenticator _authenticator;

        public static ApiUser User()
        {
            return new ApiUser { Identifier = Environment.MachineName };
        }

        public static IMvcAuthenticator MvcAuthenticator()
        {
            return MvcAuthenticator(new XeroApiSettings());
        }

        public static IMvcAuthenticator MvcAuthenticator(XeroApiSettings applicationSettings)
        {
            if (_authenticator != null)
            {
                return _authenticator;
            }

            // Set up some token stores to hold request and access tokens
            var accessTokenStore = new MemoryTokenStore();
            var requestTokenStore = new MemoryTokenStore();

            // Set the application settings with an authenticator relevant to your app type 
            switch (applicationSettings.AppType)
            {
                case XeroApiAppType.Public:
                    _authenticator = new PublicMvcAuthenticator(requestTokenStore, accessTokenStore);
                    break;
                case XeroApiAppType.Partner:
                    _authenticator = new PartnerMvcAuthenticator(requestTokenStore, accessTokenStore);
                    break;
                case XeroApiAppType.Private:
                    throw new ApplicationException("MVC cannot be used with private applications.");
                default:
                    throw new ApplicationException("Unknown app type.");
            }

            return _authenticator;
        }

        public static IXeroCoreApi CoreApi()
        {
            return new XeroCoreApi(_authenticator as IAuthenticator, User());
        }
    }
}
