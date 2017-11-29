namespace BostonScientific.BLL.Interfaces
{
    public interface ITools
    {
        // Capitalize()
        string Capitalize(string text);

        #region Encryption

        // Encrypt()
        string Encrypt(string data);

        // Decrypt()
        string Decrypt(string data);

        #endregion Encryption

        #region Managment
        
        // CreateTable_Panels()
        void CreateTable_Panels();

        // DropTable_Panels()
        void DropTable_Panels();

        // DeleteTable_Panels()
        void DeleteTable_Panels();
        
        #endregion Managment
    }
}
