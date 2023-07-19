using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace FlightsProject
{
    internal class JwtSecurityToken
    {
        private string issuer;
        private string audience;
        private DateTime expires;
        private SigningCredentials signingCredentials;
        private List<Claim> claims;
        private List<Claim> claims1;
        private List<Claim> claims2;
        private List<Claim> claims3;
        private List<Claim> claims4;
        private List<Claim> claims5;
        private List<Claim> claims6;

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            this.claims = claims;
        }

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            claims1 = claims;
        }

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            claims2 = claims;
        }

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            claims3 = claims;
        }

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            claims4 = claims;
        }

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            claims5 = claims;
        }

        public JwtSecurityToken(string issuer, string audience, DateTime expires, SigningCredentials signingCredentials, List<Claim> claims)
        {
            this.issuer = issuer;
            this.audience = audience;
            this.expires = expires;
            this.signingCredentials = signingCredentials;
            claims6 = claims;
        }
    }
}