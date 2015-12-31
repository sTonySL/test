using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApplication1
{
    class test
    {
        CookieCollection Cookies = new CookieCollection();
        HttpWebRequest Request = null;
        HttpWebResponse Response = null;

        public String LoginJxglxt(String Url,String Data)
        {
            Request = (HttpWebRequest)WebRequest.Create(Url);
            Byte[] bt = UTF8Encoding.UTF8.GetBytes(Data);

            Request.Method = "POST";
            Request.CookieContainer = new CookieContainer();
            Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //Request.Referer = "http://222.72.92.106/eams/index.do?isShowLogin=true";
            Request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.73 Safari/537.36";
            Request.ContentLength = bt.Length;
            Request.ContentType = "application/x-www-form-urlencoded";
            Request.AllowAutoRedirect = false;
            Request.GetRequestStream().Write(bt,0,bt.Length);

            Response = (HttpWebResponse)Request.GetResponse();
            Cookies = Response.Cookies;
            using (System.IO.StreamReader Sr=new System.IO.StreamReader(Response.GetResponseStream()))
            {
                return Sr.ReadToEnd();
            }
        }

        public String GetRequest(String Url)
        {
            Request = (HttpWebRequest)WebRequest.Create(Url);

            Request.CookieContainer = new CookieContainer();
            Request.CookieContainer.Add(Cookies);
            Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            Request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.73 Safari/537.36";
            // Request.Referer = "http://222.72.92.106/eams/defaultHome.do?method=moduleList&parentCode=";
            Request.AllowAutoRedirect = false;
            Response = (HttpWebResponse)Request.GetResponse();
            using (System.IO.StreamReader Sr=new System.IO.StreamReader(Response.GetResponseStream()))
            {
                var fs= Sr.ReadToEnd();
                return fs;
            }
        }

        public String PostRequest(String Url,String Data)
        {
            Request = (HttpWebRequest)WebRequest.Create(Url);
            Byte[] bt = UTF8Encoding.UTF8.GetBytes(Data);

            Request.Method = "POST";
            Request.CookieContainer = new CookieContainer();
            Request.CookieContainer.Add(Cookies);
            Request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            //Request.Referer = "http://222.72.92.106/eams/index.do?isShowLogin=true";
            Request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.73 Safari/537.36";
            Request.ContentLength = bt.Length;
            Request.ContentType = "application/x-www-form-urlencoded";
            Request.AllowAutoRedirect = false;
            Request.GetRequestStream().Write(bt, 0, bt.Length);

            Response = (HttpWebResponse)Request.GetResponse();
            using (System.IO.StreamReader Sr = new System.IO.StreamReader(Response.GetResponseStream()))
            {
                return Sr.ReadToEnd();
            }
        }

        public void Close()
        {
            if (Request!=null)
            {
                Request.Abort();
            }
            if (Response!=null)
            {
                Response.Close();
            }
        }

    }
}
