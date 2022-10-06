using System;
using System.Collections.Generic;
using idrsolutions_csharp_client;

class ExampleUsage
{
    static void Main(string[] args)
    {
        var client = new IDRCloudClient("http://cloud.idrsolutions.com/cloud/" + IDRCloudClient.BUILDVU);

        try
        {
            // Convert takes a Dictionary of the API parameters, that then get passed onto 
            // the server. For example, callbackUrl will provide a URL that you want to have
            // a request sent to when the conversion finishes.
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                ["input"] = IDRCloudClient.UPLOAD,
                ["file"] = "path/to/input.pdf"
            };

            // Alternatively send a URL for the server to download file from
            /*Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                ["input"] = IDRCloudClient.DOWNLOAD,
                ["url"] = "http://link.to/filename"
            };*/

            // Convert() returns a Dictionary (<string, string>) which returns the values 
            // in the servers response
            Dictionary<string, string> conversionResults = client.Convert(parameters);

            String outputUrl = conversionResults["downloadUrl"];

            // You can also specify a directory to download the converted output to:
            //client.DownloadResult(conversionResults, "path/to/output/dir");

            Console.WriteLine("Converted: " + outputUrl);
        }
        catch (Exception e)
        {
            Console.WriteLine("File conversion failed: " + e.Message);
        }
    }
}
