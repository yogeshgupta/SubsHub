/*
 *  SubsHub,an opensource subtitle downloader for movies and TV series.  
    Copyright (C) 2014  Yogesh Gupta

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using CookComputing.XmlRpc;
using System.Net;
using GetHash;
using System.IO.Compression;

namespace subhub
{
    
    public partial class Main : Form
    {
        public Main()
        {
            
            InitializeComponent();
        }

        
        bool isSmartDownload = true;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Brwsbtn_Click(object sender, EventArgs e)
        {
            if (Dirbtn.Checked)
            {
                folderBrowserDialog1.ShowDialog();
                Pathtb.Text = folderBrowserDialog1.SelectedPath;   
            }
            else
            {
                openFileDialog1.ShowDialog();
             //   openFileDialog1.Filter = "Avi (*.avi)|*.avi|MKV (*.mkv)|*.mkv|RMVB (*.rmvb)|*.rmvb|WMV (*.wmv)|*.wmv";
                Pathtb.Text = openFileDialog1.FileName;
            }
        }
        private void Pathtb_TextChanged(object sender, EventArgs e)
        {
            //if(Dirbtn.Checked)
            //    Pathtb.Text = folderBrowserDialog1.SelectedPath;
            //else                
            //    Pathtb.Text = openFileDialog1.FileName;
        }

        private void Dwnldbtn_Click(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception) { }
        }
        private delegate void DoWorkDelegate(string msg);

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            
            if (System.IO.Directory.Exists(Pathtb.Text))
            {

                var filePath = Directory.GetFiles(Pathtb.Text, "*.*", SearchOption.AllDirectories).Where(s => s.EndsWith(".avi", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".wmv", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".m4v", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".3gp", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".rm", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".rmvb", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".flv", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".xvid", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".x264", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mpeg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mpg", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".h264", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".swf", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".vob", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mov", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".mkv", StringComparison.OrdinalIgnoreCase) || s.EndsWith(".movx", StringComparison.OrdinalIgnoreCase));
                int ch=filePath.Count();
                AppendSuccess("Total video files found: " + ch.ToString());
                foreach (string filePaths in filePath)
                {
                    DownSub(filePaths);
                }
                MessageBox.Show("Subtitles Downloaded", "SubsHub", MessageBoxButtons.OK, MessageBoxIcon.Information);
         //       AppendSuccess("Total video files found: "+filePaths.Length.ToString());
        //        DownSub(filePaths);
                  
            }
            else if (System.IO.File.Exists(Pathtb.Text))
            {
                string filepath = openFileDialog1.FileName;
                DownSub(filepath);
              //  MessageBox.Show("All subs downloaded");
                
            }
            else
                MessageBox.Show("Please select a valid dir or file");
            
        }

        public void DownSub(string[] paths)
        {
            WebClient Client=new WebClient();
            int filelnth = paths.Length;
            if (IsConnectedToInternet())
            {
                Opensubhub subhub = (Opensubhub)XmlRpcProxyGen.Create(typeof(Opensubhub));
                string[] hashcode = new string[filelnth];
                double[] bytesize = new double[filelnth];
                for (int i = 0; i < filelnth; i++)
                {
                    byte[] hashsize = GetHash.Main.ComputeHash(paths[i]);
                    hashcode[i] = GetHash.Main.ToHexadecimal(hashsize);
                    FileInfo info = new FileInfo(paths[i]);
                    bytesize[i] = info.Length;
                }
                LoginRequest inrequest;
                LogoutRequest outrequest;
                FileDet[] detail = new FileDet[1];
                SubReturn returndetails;
                try
                {
                    inrequest = subhub.LogIn("", "", "en", "OS Test User Agent");
                    for (int k = 0; k < filelnth; k++)
                    {
                        AppendSuccess("Searching subtitle for: " + paths[k].Substring((paths[k].LastIndexOf("\\") + 1), (paths[k].Length - (paths[k].LastIndexOf("\\") + 1))));
                        detail[0].sublanguageid = "eng";
                        detail[0].moviehash = hashcode[k];
                        detail[0].moviebytesize = bytesize[k];
                        try
                        {
                            returndetails = subhub.SearchSubtitles(inrequest.token, detail);
                            string result = "";
                            if (returndetails.data[0].SubBad != "1")
                            {
                                AppendSuccess("Sutitle Found");
                                string rating1 = returndetails.data[0].SubRating;
                                double ch = Convert.ToDouble(rating1);
                                result = returndetails.data[0].SubDownloadLink;
                                for (int j = 1; j < returndetails.data.Length; j++)
                                {
                                    string rating2 = returndetails.data[j].SubRating;
                                    double ch2 = Convert.ToDouble(rating2);
                                    if (ch2 > ch)
                                    {
                                        result = returndetails.data[j].SubDownloadLink;
                                        ch = ch2;
                                    }
                                }
                            }
                            if (result != null)
                            {
                                int ch1 = paths[k].LastIndexOf("\\");
                                int ch2 = paths[k].LastIndexOf(".");
                                string pth = paths[k].Substring(0, (ch1));
                                string ext = paths[k].Substring(ch1, (ch2 - ch1)) + ".gz";
                                string pth1 = pth + ext;
                                string ext1 = paths[k].Substring(ch1, (ch2 - ch1)) + ".srt";
                                string pth2 = pth + ext1;
                                Client.DownloadFile(result, pth1);
                                TestDecompress(pth1, pth2);
                                File.Delete(pth1);
                                AppendSuccess("Subtitle saved");
                            }
                        }
                        catch (Exception)
                        {
                            AppendSuccess("Subtitle not found for " + paths[k].Substring((paths[k].LastIndexOf("\\") + 1), (paths[k].Length - (paths[k].LastIndexOf("\\") + 1))));
                        }

                    }

                    /*  sb = subhub.DownloadSubtitles(inrequest.token, result);
                      for (int i = 0; i < sb.data.Length; i++)
                      {
                         string s=base64Decode(sb.data[i].data);
                            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                          Byte[] bytes = encoding.GetBytes(s);
                          //  string str = UnZipStr(s); 
                          int ch1=paths[i].LastIndexOf("\\");
                          int ch2=paths[i].LastIndexOf(".");
                          string pth=paths[i].Substring(0,(ch1));
                          string ext = paths[i].Substring(ch1,(ch2-ch1 ))+".srt";
                          pth=pth+ext;
                         using (System.IO.FileStream fs = System.IO.File.Create(pth))
                          {
                          }
                          StreamWriter sw = new StreamWriter(pth);
                          sw.Write(sb.data[i].data);
                      }*/

                    outrequest = subhub.LogOut(inrequest.token);
                    MessageBox.Show("All Subtitles downloaded");
                }
                catch (Exception ex)
                {
                  //  HandleException(ex);
                }
            }
            else
                MessageBox.Show("Please check your internect connection");
        }

        public void DownSub(string paths)
        {
            //13Oct,2013 - Added check for existing subtitles(Smart download option)  by Ajay Singh of techovity.com(ajay0055@gmail.com)
            if (isSmartDownload && SubtitleExists(paths))
            {
                AppendSuccess("Skipping Download for: " + paths.Substring((paths.LastIndexOf("\\") + 1), (paths.Length - (paths.LastIndexOf("\\") + 1)))+ "as video file already have Subtitle (*.srt) file available. Uncheck 'Smart Download' to stop this." );
                return;
            }
            WebClient Client = new WebClient();
            if (IsConnectedToInternet())
            {
                Opensubhub subhub = (Opensubhub)XmlRpcProxyGen.Create(typeof(Opensubhub));
               
                byte[] hashsize = GetHash.Main.ComputeHash(paths);
                string hashcode = GetHash.Main.ToHexadecimal(hashsize);
                FileInfo info = new FileInfo(paths);
                double bytesize = info.Length;
                LoginRequest inrequest;
                LogoutRequest outrequest;
                FileDet[] detail = new FileDet[1];
                SubReturn returndetails;
                try
                {
                    inrequest = subhub.LogIn("", "", "en", "OS Test User Agent");
                    detail[0].sublanguageid = Properties.Settings.Default.langPref;
                    detail[0].moviehash = hashcode;
                    detail[0].moviebytesize = bytesize;
                    AppendSuccess("Searching subtitle for: " + paths.Substring((paths.LastIndexOf("\\") + 1), (paths.Length - (paths.LastIndexOf("\\")+1))));
                    returndetails = subhub.SearchSubtitles(inrequest.token, detail);
                    string result = "";
                    if (returndetails.data[0].SubBad != "1")
                    {
                        string rating1 = returndetails.data[0].SubRating;
                        double ch = Convert.ToDouble(rating1);
                        result = returndetails.data[0].SubDownloadLink;
                        for (int j = 0; j < returndetails.data.Length; j++)
                        {
                            string rating2 = returndetails.data[j].SubRating;
                            double ch2 = Convert.ToDouble(rating2);
                            if (ch2 > ch)
                            {
                                result = returndetails.data[j].SubDownloadLink;
                                ch = ch2;
                            }
                        }
                    }
                    if (result != null)
                    {
                        AppendSuccess("Subtitle Found");
                        // MessageBox.Show(result[i]);
                        int ch1 = paths.LastIndexOf("\\");
                        int ch2 = paths.LastIndexOf(".");
                        string pth = paths.Substring(0, (ch1));
                        string ext = paths.Substring(ch1, (ch2 - ch1)) + ".gz";
                        string pth1 = pth + ext;
                        string ext1 = paths.Substring(ch1, (ch2 - ch1)) + ".srt";
                        string pth2 = pth + ext1;
                        Client.DownloadFile(result, pth1);
                        TestDecompress(pth1, pth2);
                        File.Delete(pth1);
                        AppendSuccess("Subtitle Downloaded");
                    }
                    outrequest = subhub.LogOut(inrequest.token);
                 //   MessageBox.Show("All subs downloaded");
                }
                catch (Exception ex)
                {
                    AppendSuccess("Subtitle not found for " + paths.Substring((paths.LastIndexOf("\\") + 1), (paths.Length - (paths.LastIndexOf("\\") + 1))));
                   // HandleException(ex);
                }
            }
            else
                MessageBox.Show("Please check your net connection");
        }

        //13Oct,2013 -Check if .srt file available for the given Video file(Smart Download) by Ajay Singh of techovity.com(ajay0055@gmail.com)
        private bool SubtitleExists(string paths)
        { 
            int ch1 = paths.LastIndexOf("\\");
            int ch2 = paths.LastIndexOf(".");
            string pth = paths.Substring(0, (ch1));
          
            string subtitleName = paths.Substring(ch1, (ch2 - ch1)) + ".srt";
            string subtitlePath = pth + subtitleName;
            if (System.IO.File.Exists(subtitlePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void AppendSuccess(string msg)
        {
            if (this.InvokeRequired)
            {
                DoWorkDelegate dg = new DoWorkDelegate(AppendSuccess);
                this.Invoke(dg, new object[] { msg });
            }
            else
            {
                
                vsubdwnldr.Items.Insert(0, msg);
            }
        }

       /*
        private string base64Decode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }

           public static string UnZipStr(string input)
           {
               byte[] gZipBuffer = Convert.FromBase64String(input);
               using (var memoryStream = new MemoryStream())
               {
                   int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                   memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                   byte[] buffer = new byte[dataLength];
                   memoryStream.Position = 0;
                   using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
                   {
                       gZipStream.Read(buffer, 0, buffer.Length);
                   }

                   return Encoding.UTF8.GetString(buffer);
               }
           }*/

        private void HandleException(Exception ex)
        {
            string msgBoxTitle = "Error";
            try
            {
                throw ex;
            }
            catch (XmlRpcFaultException fex)
            {
                MessageBox.Show("Fault Response: " + fex.FaultCode + " "
                  + fex.FaultString, msgBoxTitle,
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (WebException webEx)
            {
                MessageBox.Show("WebException: " + webEx.Message, msgBoxTitle,
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (webEx.Response != null)
                    webEx.Response.Close();
            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message, msgBoxTitle,
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TestDecompress(string srcFile,string dstFile)
        {
            FileStream fsIn = null; // will open and read the srcFile
            FileStream fsOut = null; // will be used by the GZipStream for output to the dstFile
            GZipStream gzip = null;
            const int bufferSize = 4096;
            byte[] buffer = new byte[bufferSize];
            int count = 0;

            try
            {

                fsIn = new FileStream(srcFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                fsOut = new FileStream(dstFile, FileMode.Create, FileAccess.Write, FileShare.None);
                gzip = new GZipStream(fsIn, CompressionMode.Decompress, true);
                while (true)
                {
                    count = gzip.Read(buffer, 0, bufferSize);
                    if (count != 0)
                    {
                        fsOut.Write(buffer, 0, count);
                    }
                    if (count != bufferSize)
                    {
                        // have reached the end
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // handle or display the error 
                System.Diagnostics.Debug.Assert(false, ex.ToString());
            }
            finally
            {
                if (gzip != null)
                {
                    gzip.Close();
                    gzip = null;
                }
                if (fsOut != null)
                {
                    fsOut.Close();
                    fsOut = null;
                }
                if (fsIn != null)
                {
                    fsIn.Close();
                    fsIn = null;
                }
            }
        }

        private void Cnclbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool IsConnectedToInternet()
        {
            try
            {
                System.Net.Sockets.TcpClient clnt = new System.Net.Sockets.TcpClient("www.google.com", 80);
                clnt.Close();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void projectPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prjctpg pg = new Prjctpg();
            pg.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abtus abt = new abtus();
            abt.Show();
        }

        private void subtitleLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublang ls = new Sublang();
            ls.ShowDialog();
           // this.Close();
        }

        //13/10/2013 - Smart Download option by Ajay Singh of techovity.com(ajay0055@gmail.com)
        private void chkSmartDownload_CheckedChanged(object sender, EventArgs e)
        {
            
            isSmartDownload = chkSmartDownload.Checked;
        }

        //13/10/2013 -Clear UI option by Ajay Singh of techovity.com(ajay0055@gmail.com).
        private void btnClearScreen_Click(object sender, EventArgs e)
        {
            vsubdwnldr.Items.Clear();
        }


       
    }
}
