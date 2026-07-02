using BCrypt.Net;
public static class PasswordHashingService
{
    public static string HashAndSaltPassword(string raw)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(raw);
    }

    public static bool VerifyHash(string raw, string hash)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(raw, hash);
    }
    // usage will look like this in our consumer class: if(!PasswordHashingService.VerifyHash("password", user.PasswordHash)) { // handle error here <- }
}