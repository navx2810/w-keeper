using System.Collections.Generic;
using Newtonsoft.Json;

namespace Keeper.Code.Auth.Challenges
{
    public class BasicErrors : IErrors
    {
        private List<ErrorPair> Errors { get; set; } =  new List<ErrorPair>();
        public void Add(string challenge, string message)
        {
            Add(new ErrorPair { Name = challenge, Msg = message });
        }
        public void Add(ErrorPair error)
        {
            this.Errors.Add(error);
        }
        public bool HasAny => this.Errors.Count > 0;

        public string Response => JsonConvert.SerializeObject(this.Errors);

        public override string ToString()
        {
            return Response;
        }
    }
}