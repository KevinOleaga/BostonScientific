using BostonScientific.BLL.Interfaces;
using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.BLL.Methods
{
    public class MSwitch : ISwitch
    {
        private DAL.Interfaces.ISwitch _switch;
        public MSwitch()
        {
            _switch = new DAL.Methods.MSwitch();
        }

        // GetData()
        public DATA.testData[] GetData(string IdSwitch)
        {
            return _switch.GetData(IdSwitch);
        }

        // DeleteSwitch()
        public void DeleteSwitch(string IdSwitch)
        {
            _switch.DeleteSwitch(IdSwitch);
        }

        // SendFileToS3()
        public void SendFileToS3(Stream FileStream, string FileName, string IdSwitch)
        {
            _switch.SendFileToS3(FileStream, FileName, IdSwitch);
        }
        
        public int CountFiles(string IdSwitch)
        {
            return _switch.CountFiles(IdSwitch);
        }
        
        public Files[] GetFiles(string IdSwitch)
        {
            return _switch.GetFiles(IdSwitch);
        }

        public void DownloadDoc(string FileName)
        {
            _switch.DownloadDoc(FileName);
        }

        public int GetData2(string IdSwitch)
        {
            return _switch.GetData2(IdSwitch);
        }

    }
}
