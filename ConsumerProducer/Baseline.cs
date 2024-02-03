using System.Net;

namespace ConsumerProducer
{
    public class Baseline
    {
        IEnumerable<string> hostNameAddresses { get; set; }

        List<string> ipAddresses { get; set; }

        public Baseline()
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            var dir = "C:\\Users\\jonth\\consumer-producer-buffer\\ConsumerProducer\\";
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string sFile = System.IO.Path.Combine(dir, "input\\names1.txt");
            hostNameAddresses = File.ReadLines(sFile);

            ipAddresses = new List<string>();
        }

        public void ResolveNames()
        {
            foreach(var name in hostNameAddresses)
            {
                IPHostEntry hostEntry;

                hostEntry = Dns.GetHostEntry(name);

                //hostEntry.AddressList.FirstOrDefault().AddressFamily.ToString();
                if(hostEntry.AddressList?.Length == 2)
                {
                    ipAddresses.Add(hostEntry.AddressList[1].ToString());
                }
                else if (hostEntry.AddressList?.Length == 1)
                {
                    ipAddresses.Add(hostEntry.AddressList[0].ToString());
                }
                else
                {
                    ipAddresses.Add(hostEntry.AddressList?.First().MapToIPv4().ToString() ?? "null");
                }
            }
        }
    }
}