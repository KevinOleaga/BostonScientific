namespace BostonScientific.DAL.Interfaces
{
    public interface IPhrases
    {
        #region Site.Master

        // GetRandomPhrase()
        string GetRandomPhrase();

        #endregion Site.Master

        #region Managment

        // CreateTable()
        void CreateTable();

        // DropTable()
        void DropTable();
        
        // DeleteTable()
        void DeleteTable();

        #endregion Managment
    }
}
