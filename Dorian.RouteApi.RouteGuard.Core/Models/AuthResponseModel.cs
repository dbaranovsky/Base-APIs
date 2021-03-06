﻿using Dorian.RouteApi.Infrastructure.Models;
using Newtonsoft.Json;

namespace Dorian.RouteApi.RouteGuard.Core.Models
{
    public class AuthResponseModel : IAccessTokenModel
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expired_in")]
        public string ExpiredIn { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }
    }
}
