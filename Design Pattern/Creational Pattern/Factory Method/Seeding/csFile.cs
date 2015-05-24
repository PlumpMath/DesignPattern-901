using System.IO;

namespace Seeding
{
    /// <summary>
    /// A simple file handlng class
    /// </summary>
    public class CsFile
    {
        private string _fileName;
        private StreamReader _ts;
        private StreamWriter _ws;
        private bool _opened, _writeOpened;

        //-----------
        public CsFile()
        {
            Init();
        }

        //-----------
        private void Init()
        {
            _opened = false;
            _writeOpened = false;
        }

        //-----------
        public CsFile(string fileName)
        {
            _fileName = fileName;
            Init();
        }

        //-----------
        public bool OpenForRead(string fileName)
        {
            _fileName = fileName;
            try
            {
                _ts = new StreamReader(_fileName);
                _opened = true;
            }
            catch (FileNotFoundException e)
            {
                return false;
            }
            return true;
        }

        //-----------
        public bool OpenForRead()
        {
            return OpenForRead(_fileName);
        }

        //-----------
        public string ReadLine()
        {
            return _ts.ReadLine();
        }

        //-----------
        public void WriteLine(string s)
        {
            _ws.WriteLine(s);
        }

        //-----------
        public void Close()
        {
            if (_opened)
                _ts.Close();
            if (_writeOpened)
                _ws.Close();
        }

        //-----------
        public bool OpenForWrite()
        {
            return OpenForWrite(_fileName);
        }

        //-----------
        public bool OpenForWrite(string fileName)
        {
            try
            {
                _ws = new StreamWriter(fileName);
                _fileName = fileName;
                _writeOpened = true;
                return true;
            }
            catch (FileNotFoundException e)
            {
                return false;
            }
        }
    }
}