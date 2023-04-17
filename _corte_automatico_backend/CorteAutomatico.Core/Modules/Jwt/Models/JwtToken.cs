namespace CorteAutomatico.Core.Modules.Jwt.Models;

public class JwtToken
{
    public JwtToken(string accessToken, string refreshToken, DateTime refreshTokenExpiryTime,
                    DateTime accessTokenExpiryTime)
    {
        AccessToken = accessToken ?? throw new ArgumentNullException(nameof(accessToken));
        RefreshToken = refreshToken ?? throw new ArgumentNullException(nameof(refreshToken));
        RefreshTokenExpiryTime = refreshTokenExpiryTime;
        AccessTokenExpiryTime = accessTokenExpiryTime;
    }
    public string AccessToken { get; } = null!;
    public string RefreshToken { get; } = null!;
    public DateTime RefreshTokenExpiryTime { get; set; }
    public DateTime AccessTokenExpiryTime { get; set; }
}