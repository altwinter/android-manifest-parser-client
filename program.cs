using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcManifestParserClient;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:7037");
            var client = new ManifestParser.ManifestParserClient(channel);


            string manifest = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"resource/AndroidManifest-instagram-bin.xml");
            string apk = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"resource/Instagram.apk");


            // Console.WriteLine(manifest);
            // Console.WriteLine(apk);
            var reply = await client.ParseDataAsync(
                              new ManifestInfo { Sha1 = "sha1Id", ManifestPath = manifest, ApkPath = apk });

            Console.WriteLine("As been executed: " + Convert.ToString(reply.Response));
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
