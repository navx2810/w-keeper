namespace Keeper.Code.Auth
{
    public interface ITokenizer<ServerUser, ClientUser>
    {
        string Encode(ServerUser user);
        string Encode(ClientUser user);
        ClientUser Decode(string token);
        bool Validate(string token);
    }
}