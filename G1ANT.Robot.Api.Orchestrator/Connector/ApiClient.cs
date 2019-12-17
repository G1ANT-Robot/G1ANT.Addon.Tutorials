using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;

namespace G1ANT.Robot.Api.Orchestrator.Connector
{
    public class ApiClient
    {
        public string Token { get; set; } = string.Empty;
        public string Machine { get; set; } = "localhost";
        public int Port { get; set; } = 1234;
        public string SerialNumber { get; set; } = string.Empty;

        public ApiClient(string machine = "localhost", int port = 1234, string serialNumber = "", string token = "")
        {
            Machine = machine;
            Port = port;
            Token = token;
            SerialNumber = serialNumber;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }

        public string SendFile(string fileName, string query = "", string parameters = "")
        {
            string url = $"http://{Machine}:{Port}{query}/?token={Token}&serialnumber={SerialNumber}&{parameters}";

            System.IO.FileInfo file = new System.IO.FileInfo(fileName);
            int fileLength = (int)file.Length;

            string boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x");
            byte[] boundarybytes = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "\r\n");

            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Method = "POST";
            request.KeepAlive = true;

            using (System.IO.Stream stream = request.GetRequestStream())
            {
                stream.Write(boundarybytes, 0, boundarybytes.Length);

                byte[] headerbytes = System.Text.Encoding.UTF8.GetBytes(
                    "Content-Disposition: form-data; name=\"content\"; filename=\"" + file.Name + "\"\r\n\r\n");
                stream.Write(headerbytes, 0, headerbytes.Length);

                System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                stream.Write(System.IO.File.ReadAllBytes(fileName), 0, fileLength);
                fileStream.Close();

                byte[] trailer = System.Text.Encoding.ASCII.GetBytes("\r\n--" + boundary + "--\r\n");
                stream.Write(trailer, 0, trailer.Length);
            }
            using (System.IO.Stream stream = request.GetResponse().GetResponseStream())
                return new System.IO.StreamReader(stream).ReadToEnd();
        }

        public string Post(string query, string body, string parameters = "")
        {
            string url = $"http://{Machine}:{Port}{query}/?token={Token}&serialnumber={SerialNumber}&{parameters}";
            WebClient client = new WebClient();
            return client.UploadString(url, "POST", body);
        }

        public string Put(string query, string body, string parameters = "")
        {
            string url = $"http://{Machine}:{Port}{query}/?token={Token}&serialnumber={SerialNumber}&{parameters}";
            WebClient client = new WebClient();
            return client.UploadString(url, "PUT", body);
        }

        public string Get(string query, string parameters = "")
        {
            string url = $"http://{Machine}:{Port}{query}/?token={Token}&serialnumber={SerialNumber}&{parameters}";
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }
    }
}
