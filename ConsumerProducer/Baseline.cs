namespace ConsumerProducer
{
    public class Baseline
    {
        IEnumerable<string> addresses { get; set; }

        public Baseline()
        {
            // This will get the current WORKING directory (i.e. \bin\Debug)
            string workingDirectory = Environment.CurrentDirectory;
            // or: Directory.GetCurrentDirectory() gives the same result
            var dir = "C:\\Users\\jonth\\consumer-producer-buffer\\ConsumerProducer\\";
            // This will get the current PROJECT directory
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            string sFile = System.IO.Path.Combine(dir, "input\\names1.txt");
            addresses = File.ReadLines(sFile);
        }
    }
}