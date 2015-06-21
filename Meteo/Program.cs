using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Parser;
using System.IO;

namespace Meteo
{
    class Program
    {
        static void Main(string[] args)
        {
            LOG log = LOG.GetInstance();
            FileParser parser = new FileParser("files/2-таэ-3.txt");
            parser.Read();

            Console.ReadKey();
            LOG.GetInstance().Commit();
        }
    }
}
