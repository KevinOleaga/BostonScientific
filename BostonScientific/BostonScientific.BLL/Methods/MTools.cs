using BostonScientific.BLL.Interfaces;

namespace BostonScientific.BLL.Methods
{
    public class MTools : ITools
    {
        private DAL.Interfaces.ITools _tools;
        public MTools()
        {
            _tools = new DAL.Methods.MTools();
        }

        // Capitalize()
        public string Capitalize(string text)
        {
            return _tools.Capitalize(text);
        }

        #region Encryption

        public string Encrypt(string data)
        {
            return _tools.Encrypt(data);
        }

        public string Decrypt(string data)
        {
            return _tools.Decrypt(data);
        }

        #endregion Encryption

        #region Managment

        // CreateTable_Panels()
        public void CreateTable_Panels()
        {
            _tools.CreateTable_Panels();
        }

        // DropTable_Panels()
        public void DropTable_Panels()
        {
            _tools.DropTable_Panels();
        }

        // DeleteTable_Panels()
        public void DeleteTable_Panels()
        {
            _tools.DeleteTable_Panels();
        }

        #endregion Managment
    }
}

