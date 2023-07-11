using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using MimeKit;
using System.Linq;
using System.IO;

namespace MailChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var client = new ImapClient())
            {
                client.Connect(Settings.HostAdress, Settings.HostPort, true);
                client.Authenticate(Settings.EmailUsername, Settings.EmailPassword);

                Console.WriteLine($"Подключение {client.IsConnected}, авторизация {client.IsAuthenticated}.");

                client.Inbox.Open(FolderAccess.ReadOnly);

                var uids = client.Inbox.Search(SearchQuery.SentSince(DateTime.Now.AddDays(-7)));

                var messages = client.Inbox.Fetch(uids, MessageSummaryItems.Envelope | MessageSummaryItems.BodyStructure);

                if(messages != null && messages.Count > 0) 
                {
                    foreach(var message in messages) 
                    {
                        if(message.Attachments != null && message.Attachments.Count() > 0)
                        {
                            foreach(var attachment in message.Attachments.OfType<BodyPartBasic>())
                            {
                                var part = (MimePart)client.Inbox.GetBodyPart(message.UniqueId, attachment);

                                var pathDir = Path.Combine(Environment.CurrentDirectory, "Emails", message.UniqueId.ToString());
                                if(!Directory.Exists(pathDir))
                                {
                                    Directory.CreateDirectory(pathDir);
                                }

                                var path = Path.Combine(pathDir, part.FileName);
                                if(!File.Exists(path)) 
                                {
                                    using (var strm = File.Create(path))
                                    {
                                        part.Content.DecodeTo(strm);
                                    }
                                }
                            }
                        }
                    }
                }

                client.Disconnect(true);
            }
        }
    }
}