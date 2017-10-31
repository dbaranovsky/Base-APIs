namespace Api.Infrastructure.Models
{
    public interface IAccessTokenModel
    {
        string AccessToken { get; set; }

        string ExpiredIn { get; set; }

        string TokenType { get; set; }
    }
}
