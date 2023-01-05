using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpg.Src
{
    internal class FileIoManager : ISingelton<FileIoManager>
    {
        private FileIoManager instance = new FileIoManager();

        private FileIoManager()
        {

        }

        public FileIoManager getInstance()
        {
            if (instance == null)
            {
                instance = new FileIoManager();
                return instance;
            }
            else
            {
                return instance;
            }
        }
    }
}
