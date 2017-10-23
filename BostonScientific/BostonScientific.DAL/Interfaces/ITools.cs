namespace BostonScientific.DAL.Interfaces
{
    public interface ITools
    {
        // Capitalize()
        string Capitalize(string text);

        // Encrypt()
        string Encrypt(string data);
        
        // Decrypt()
        string Decrypt(string data);

        #region DynamoDB

        // CreateTable_Users()
        void CreateTable_Users();

        #endregion DynamoDB
    }
}
