namespace bikestore.Core.Common
{
    public static class Utils
	{
        public static string EncryptedPassword(string password, string salt = null)
        {
            var cryptoher = new Cryptopher();
            if (!string.IsNullOrEmpty(salt))
                cryptoher.AppKeySalt = salt;
            return cryptoher.PasswordHash(password);
        }
    }
}

