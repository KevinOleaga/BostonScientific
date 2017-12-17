using BostonScientific.DATA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BostonScientific.BLL.Interfaces
{
    public interface ISwitch
    {
        // GetData()
        testData[] GetData(string IdSwitch);

        // DeleteSwitch()
        void DeleteSwitch(string IdSwitch);

        // SendFileToS3()
        void SendFileToS3(Stream FileStream, string FileName, string IdSwitch);

        int CountFiles(string IdSwitch);

        Files[] GetFiles(string IdSwitch);

        void DownloadDoc(string FileName);

        int GetData2(string IdSwitch);

    }
}
