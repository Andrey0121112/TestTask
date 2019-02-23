using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestTask.Client.item;
using TestTask.Client.model;

namespace TestTask.Client
{
    public class ServiceButton
    {

        public static void ApiGetAll(ServerAPI serverAPI)
        {
            var client = new RestClient(serverAPI.API);
            var request = new RestRequest("api/values", Method.GET);
            var response = client.Execute<List<Phone>>(request);
            var queryResult = response.Data;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"{response.ErrorMessage} ", "ERROR", System.Windows.MessageBoxButton.OK);
                return;
            }

            queryResult.ForEach(x => serverAPI.ListItem.Add(new PhoneModel() { Id = x.id.ToString(), Name = x.name, Data = ImageConvertData(x.data, x.name, serverAPI) }));
        }

        public static void ApiDelete(ServerAPI serverAPI)
        {
            var client = new RestClient(serverAPI.API);
            var request = new RestRequest("api/values/{id}", Method.DELETE);
            request.AddParameter("id", serverAPI.selectItem.Id, ParameterType.UrlSegment);
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"{response.ErrorMessage} ", "ERROR", System.Windows.MessageBoxButton.OK);
            }

        }

        public static void ApiSave(ServerAPI serverAPI)
        {
            string dataImage = "image//" + Path.GetExtension(serverAPI.selectItem.Data) + ";base64,";
            Byte[] bytes = File.ReadAllBytes(serverAPI.selectItem.Data);
            String data = dataImage + Convert.ToBase64String(bytes);


            var client = new RestClient(serverAPI.API);
            var request = new RestRequest("api/values", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new Phone() { name = serverAPI.selectItem.Name, data = data });
            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"{response.ErrorMessage} ", "ERROR", System.Windows.MessageBoxButton.OK);
            }

        }

        public static void ApiChange(ServerAPI serverAPI)
        {

            string dataImage = "image//" + Path.GetExtension(serverAPI.selectItem.Data) + ";base64,";
            Byte[] bytes = File.ReadAllBytes(serverAPI.selectItem.Data);
            String data = dataImage + Convert.ToBase64String(bytes);

            var client = new RestClient(serverAPI.API);
            var request = new RestRequest("api/values/{id}", Method.PUT) { RequestFormat = DataFormat.Json };
            request.AddParameter("id", serverAPI.selectItem.Id, ParameterType.UrlSegment);
            request.AddBody(new Phone() { id = int.Parse(serverAPI.selectItem.Id), name = serverAPI.selectItem.Name, data = data });

            var response = client.Execute(request);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                System.Windows.MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show($"{response.ErrorMessage} ", "ERROR", System.Windows.MessageBoxButton.OK);
            }

        }


        private static string ImageConvertData(string base64String, string name, ServerAPI serverAPI)
        {
            Directory.CreateDirectory(serverAPI.folder);
            string currentpath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string exten = base64String.Substring(base64String.IndexOf("."), base64String.IndexOf(";") - base64String.IndexOf("."));
            string path = Path.Combine(currentpath, serverAPI.folder, name + exten);
            base64String = base64String.Substring(base64String.IndexOf(",") + 1);
            var contents = new MemoryStream(Convert.FromBase64String(base64String));
            using (FileStream file = File.OpenWrite(path))
            {
                file.Write(contents.ToArray(), 0, (int)contents.Length);
            }


            return path;
        }
    }
}
