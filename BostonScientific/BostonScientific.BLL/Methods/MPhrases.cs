using BostonScientific.BLL.Interfaces;

namespace BostonScientific.BLL.Methods
{
    public class MPhrases : IPhrases
    {
        private DAL.Interfaces.IPhrases _pharses;
        public MPhrases()
        {
            _pharses = new DAL.Methods.MPhrases();
        }

        #region Site.Master

        // GetRandomPhrase()
        public string GetRandomPhrase()
        {
            return _pharses.GetRandomPhrase();
        }

        #endregion Site.Master

        #region Managment

        // CreateTable()
        public void CreateTable()
        {
            _pharses.CreateTable();
        }

        // DropTable()
        public void DropTable()
        {
            _pharses.DropTable();
        }

        // DeleteTable()
        public void DeleteTable()
        {
            _pharses.DeleteTable();
        }
        
        #endregion Managment
    }
}
