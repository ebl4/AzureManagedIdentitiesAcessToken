using System.Net;
using System.Text.Json;

string uri = "http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https://management.azure.com/";
var httpClient = new HttpClient();

try
{
	var response = await httpClient.GetAsync(uri);
	var streamResponse = response.Content.ReadAsStream();

	var list = JsonSerializer.Deserialize(streamResponse, typeof(Dictionary<string, string>)) as Dictionary<string, string>;
	string acessToken = list!["acess_token"];
}
catch (Exception ex)
{
	string error = String.Format("{0} \n\n{1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : "Acquire token failed");
	throw new Exception(error);
}