using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Parser
{
    public class FileParser
    {
        public string FilePath {  get; private set; }
        public bool FileExist { get; private set; }
        private StreamReader sr;
        private List<string> _lines;

        public FileParser(string _filepath)
        {
            FilePath = _filepath;

            if (File.Exists(_filepath))
            {
                LOG.GetInstance().Write(System.DateTime.Now.ToString(), "файл " + _filepath + " знайдено;");
                FileExist = true;
                sr = new StreamReader(_filepath);
                _lines = new List<string>();
            }
            else
            {
                LOG.GetInstance().Write(System.DateTime.Now.ToString(), "файл " + _filepath + " не знайдено;");
                FileExist = false;
            }
        }

        public void Read()
        {
            if (FileExist)
            {
                LOG.GetInstance().Write(System.DateTime.Now.ToString(), "розпочато зчитування даних файлу " + FilePath + ";");

                do
                {
                    _lines.Add(sr.ReadLine());
                } while (!sr.EndOfStream);

                LOG.GetInstance().Write(System.DateTime.Now.ToString(), "зчитування з файлу " + FilePath + " завершено, прочитано " + _lines.Count + " рядків;");
                sr.Close();
            }
            else
                LOG.GetInstance().Write(System.DateTime.Now.ToString(), "спроба зчитування даних з неіснуючого файлу " + FilePath + ";");

        }
    }
}
