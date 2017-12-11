namespace BostonScientific.DAL.Interfaces
{
    public interface ITools
    {
        #region Capitalize

        // CapitalizeByWord()
        string CapitalizeByWord(string data);

        // Capitalize()
        string Capitalize(string data);

        #endregion Capitalize

        #region Encryption

        // Encrypt()
        string Encrypt(string data);

        // Decrypt()
        string Decrypt(string data);

        #endregion Encryption
    }
}
