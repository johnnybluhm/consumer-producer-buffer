using System.Net;

namespace ConsumerProducer
{
    public class Baseline
    {
        List<string> hostNameAddresses { get; set; } = new List<string>();

        List<string> ipAddresses { get; set; } = new List<string>();

        List<string> badHosts { get; set; } = new List<string>();

        public Baseline()
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            var dir = "C:\\Users\\jonth\\consumer-producer-buffer\\ConsumerProducer\\";
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string sFile;
            for (int i = 0; i < 5; i++)
            {
                sFile = Path.Combine(dir, $"input\\names{i + 1}.txt");
                IEnumerable<string> hostNames = File.ReadLines(sFile);

                foreach (string hostName in hostNames)
                {
                    hostNameAddresses.Add(hostName);
                }
            }

            ipAddresses = new List<string>();
        }

        public void ResolveNames()
        {
            foreach (var name in hostNameAddresses)
            {
                IPHostEntry hostEntry;

                try
                {
                    hostEntry = Dns.GetHostEntry(name);
                }
                catch (Exception)
                {
                    badHosts.Add(name);
                    continue;
                }

                //hostEntry.AddressList.FirstOrDefault().AddressFamily.ToString();
                if (hostEntry.AddressList?.Length == 2)
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