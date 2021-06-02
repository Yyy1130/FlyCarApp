using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using FlyCarApp.Page;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace FlyCarApp.Class
{
    class ClientFun
    {
        private string ContentType { get; set; }
        private string Method { get; set; }
        public ClientFun(string method)
        {
            Method = method;
            ContentType = "application/json";
        }

        public string TestConnect(string url)
        {
            string result = "";
            HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(url + "Test");
            webreq.Method = Method;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)webreq.GetResponse())
                {
                    result = "success";
                    Application.Current.Properties["url"] = url;
                    Application.Current.SavePropertiesAsync();
                    response.Close();
                }
            }
            catch (Exception ev)
            {
                result = ev.Message;
            }
            return result;
        }
        public object PostFun(string interfacename, string SendText)
        {
            string resultjson;
            object posturl;
            ParaClass.ResultInfo result = new ParaClass.ResultInfo();
            Application.Current.Properties.TryGetValue("url", out posturl);
            byte[] byteArray = Encoding.UTF8.GetBytes(SendText);
            string url = posturl.ToString() + interfacename;
            HttpWebRequest webreq = (HttpWebRequest)WebRequest.Create(url);
            webreq.Method = Method;
            webreq.ContentType = ContentType;
            webreq.ContentLength = byteArray.Length;
            try
            {
                using (Stream newStream = webreq.GetRequestStream())
                {
                    newStream.Write(byteArray, 0, byteArray.Length);
                    newStream.Close();
                    using (HttpWebResponse response = (HttpWebResponse)webreq.GetResponse())
                    {
                        using (StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                        {
                            resultjson = sr.ReadToEnd();
                            result = (ParaClass.ResultInfo)JsonConvert.DeserializeObject(resultjson, typeof(ParaClass.ResultInfo));
                            sr.Close();
                        }
                        response.Close();
                    }
                }
            }
            catch (Exception ev)
            {
                result.code = "1";
                result.msg = ev.Message;
            }
            return result;
        }
    }
}
