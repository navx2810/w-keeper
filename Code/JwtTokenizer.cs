using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Keeper.Code.DAO;
using Keeper.Code.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Keeper.Code
{
    public class JwtTokenizer : IAppTokenizer
    {
        private IJwtEncoder encoder;
        private IJwtDecoder decoder;
        public string Secret { get; set; }

        public JwtTokenizer()
        {
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder(); 
            IDateTimeProvider provider = new UtcDateTimeProvider();
            IJwtValidator validator = new JwtValidator(serializer, provider);

            encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            decoder = new JwtDecoder(serializer, validator, urlEncoder);
        }
        public ClientUser Decode(string token)
        {
            if(string.IsNullOrEmpty(token)) { return null; }
            return decoder.DecodeToObject<ClientUser>(token, Secret, true);
        }

        public string Encode(User user)
        {
            return Encode(new ClientUser { Id = user.Id });
        }

        public string Encode(ClientUser user)
        {
            return encoder.Encode(user, Secret);
        }

        public bool Validate(string token)
        {
            throw new System.NotImplementedException();
        }
    }
}