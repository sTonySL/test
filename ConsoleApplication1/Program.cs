using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(String[] arg)
        {
            String url = "http://222.72.92.106/eams/login.do";
            String Data = "name=12042201029&isShowLogin=true&password=847945151&lang=chinese";
            String GradeUrl = "http://222.72.92.106/eams/personGrade.do";
            test first = new test();
            //first.LoginJxglxt(url,Data);
            first.Close();


        }
    }
}
