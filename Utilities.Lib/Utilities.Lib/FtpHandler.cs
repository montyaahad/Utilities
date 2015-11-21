using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Lib
{
    public static class FtpHandler
    {
        public static void UploadFile(string ftpurl, string ftpusername, string ftppassword, string filename, byte[] buffer)
        {
            try
            {
                //String ftpurl = "ftp://serverip/foldername/foldername/";
                //String ftpusername = "username";
                //String ftppassword = "password";
                //string filename = "file.txt";

                string ftpfullpath = ftpurl + filename;
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpfullpath);
                ftp.Credentials = new NetworkCredential(ftpusername, ftppassword);

                ftp.KeepAlive = true;
                ftp.UseBinary = true;
                ftp.Method = WebRequestMethods.Ftp.UploadFile;

                using (Stream ftpstream = ftp.GetRequestStream())
                {
                    ftpstream.Write(buffer, 0, buffer.Length);
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
