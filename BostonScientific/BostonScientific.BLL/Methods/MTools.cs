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

        #region Capitalize

        // CapitalizeByWord()
        public string CapitalizeByWord(string data)
        {
            return _tools.CapitalizeByWord(data);
        }

        // Capitalize()
        public string Capitalize(string data)
        {
            return _tools.Capitalize(data);
        }

        #endregion Capitalize

        #region Encryption

        // Encrypt()
        public string Encrypt(string data)
        {
            return _tools.Encrypt(data);
        }

        // Decrypt()
        public string Decrypt(string data)
        {
            return _tools.Decrypt(data);
        }

        #endregion Encryption
    }
}

