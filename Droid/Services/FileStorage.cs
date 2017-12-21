using System.IO;
using System.Text;
using Android.App;
using Android.Content;
using MyApp.Services.API;

namespace MyApp.Droid.Services
{
    public class FileStorage : IFileStorage
    {
        private Context _context = Application.Context;

        public byte[] ReadAsBytes(string filename)
        {
            var fileContents = ReadAsString(filename);

            return Encoding.ASCII.GetBytes(fileContents);
        }

        public string ReadAsString(string filename)
        {
            using (var asset = _context.Assets.Open(filename))
            using (var streamReader = new StreamReader(asset))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
