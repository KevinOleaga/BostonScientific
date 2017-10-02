using BostonScientific.DATA;

namespace BostonScientific.DAL.Interfaces
{
    public interface IPanels
    {
        // CountPanels()
        int CountPanels();

        // PanelsInfo()
        Panels[] PanelsInfo();
    }
}
