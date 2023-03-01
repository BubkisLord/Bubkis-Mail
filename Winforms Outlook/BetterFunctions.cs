using System.Net.Mail;
using System.Net;
using System.IO.Compression;

namespace BetterFunctions
{
    public class BetterFunctions
    {
        public static int Sleep(double Seconds)
        {
            Seconds *= 1000;
            Thread.Sleep((int)Seconds);
            return (int)Seconds;
        }
        public static int Sleep(int Seconds)
        {
            Seconds *= 1000;
            Thread.Sleep((int)Seconds);
            return (int)Seconds;
        }
        public static int Sleep(float Seconds)
        {
            Seconds *= 1000;
            Thread.Sleep((int)Seconds);
            return (int)Seconds;
        }
        public enum HostTypes
        {
            Office,
            Gmail
        };
        public enum Priority
        {
            Low,
            Medium,
            High
        };

        public static int RandInt(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max + 1);
        }
        public static string Print(string str = "")
        {
            Console.Write(str + "\n");
            return str;
        }
        public static string Input(string words = "")
        {
            Console.Write(words);
            string input = Console.ReadLine();
            input ??= "";
            return input;
        }
        public static int getRandInt(int minimum, int maximum)
        {
            Random random = new();
            return random.Next(minimum, maximum + 1);
        }
        public static string str(int integer)
        {
            return integer.ToString();
        }
        public static void SendMail(string email, string password, string recipient, string subject, string body, string CC, string BCC, string attachment, HostTypes hostType = HostTypes.Office, Priority priority = Priority.Medium, bool forwardToSelf = false)
        {
            MailMessage msg = new MailMessage();

            msg.From = new MailAddress(email);
            msg.To.Add(recipient);
            if (BCC != "") msg.Bcc.Add(BCC);
            if (CC != "") msg.CC.Add(CC);
            if (forwardToSelf) msg.Bcc.Add(email);
            msg.Subject = subject;
            msg.Body = body;
            if (priority == Priority.Low) msg.Priority = MailPriority.Low;
            if (priority == Priority.Medium) msg.Priority = MailPriority.Normal;
            if (priority == Priority.High) msg.Priority = MailPriority.High;
            if (attachment != "") msg.Attachments.Add(new Attachment(attachment));

            using (SmtpClient client = new SmtpClient())
            {
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                
                if (hostType != HostTypes.Office)
                {
                    client.Host = "pop3.btconnect.com";
                    client.Port = 25;
                    //client.Credentials = new NetworkCredential(email, password.Trim());
                }
                else
                {
                    client.Host = "smtp.office365.com";
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(email, password.Trim());
                }
                
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                client.Send(msg);
            }
        }  
        public static string CompressFolder(string sourceFolderName, string outputname)
        {
            DirectoryInfo d = new DirectoryInfo(sourceFolderName);

            FileInfo[] Files = d.GetFiles(); //Getting files

            using (ZipArchive archive = ZipFile.Open(Path.ChangeExtension(outputname, ".zip"), ZipArchiveMode.Create))
            {
                foreach (FileInfo file in Files)
                {
                    archive.CreateEntryFromFile(file.FullName, Path.GetFileName(file.FullName));
                }
            }
            return Path.ChangeExtension(sourceFolderName, ".zip");
        }
        public static string CompressFile(string sourceFileName, string outputname)
        {
            using (ZipArchive archive = ZipFile.Open(Path.ChangeExtension(outputname, ".zip"), ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile(sourceFileName, Path.GetFileName(sourceFileName));
            }
            return Path.ChangeExtension(outputname, ".zip");
        }
        public static string CompressFile(List<string> sourceFileNames, string outputname)
        {
            using (ZipArchive archive = ZipFile.Open(Path.ChangeExtension(outputname, ".zip"), ZipArchiveMode.Create))
            {
                foreach (string sourceFile in sourceFileNames)
                {
                    archive.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile));
                }
            }
            return Path.ChangeExtension(outputname, ".zip");
        }
        public static void DownloadFile(string URL, string outputname)
        {
            WebClient webClient = new();
            webClient.DownloadFile(URL, outputname);
            return;
        }
        public static string Curl(string URL)
        {
            WebClient webClient = new();
            string str = webClient.DownloadString(URL);
            return str;
        }
    }
}