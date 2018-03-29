using System;
using System.Threading.Tasks;

namespace DownloadFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };

            Parallel.For(1, 240, options, (i) =>
            {
                var source = $"http://radioprograms.fusionbd.com/All_Files/Kuasha/High_Quality-MP3_Version/Kuasha-Episode_{i}_FusionBD.Com.mp3";
                var downloadTo = $"d:\\Kuasha\\Kuasha-Episode_{i}_FusionBD.Com.mp3";
                try
                {
                    DownloadFileX.Download(source, downloadTo);
                    Console.WriteLine($"{i} -- {source} Downloading to => {downloadTo}");
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Exception downloading => {source} Downloading to => {downloadTo}");
                    Console.WriteLine($"Exception downloading => {ex.Message.ToString()}");
                    /// throw;
                }
            });

            Console.ReadLine();
        }
    }
}
