using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

public class ApiService
{
    private readonly string baseUrl = "https://demo1.fidpark.com/api/v1/Clients"; 
    private readonly string loginUrl = "https://demo1.fidpark.com/api/v1/Account/login";
    private string authToken = "";
    // i tried to use hardcoded token from swagger here: private string authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJkZW1vIiwianRpIjoiMTU1NTFjODMtNTJlNS00YzI4LThiMmMtMjRmZTI4NmFhZjlhIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjpbIkNsaWVudCBtYW5hZ2VtZW50IiwiVGFyaWZmIG1hbmFnZW1lbnQgaW4gem9uZXMiLCJFZGl0Q2FyZHMiLCJXZWJTZXJ2aWNlX0NyZWF0ZUNvbnRyYWN0IiwiV2ViQWRtaW5fQ2xpZW50R3JvdXBzX1JlYWQiLCJQcm9kdWN0cyBtYW5hZ2VtZW50IiwiR3VhcmRpYW5fT3BlbkJhcnJpZXJFbmFibGVkIiwiV2ViQWRtaW5fU2VydmljZXMiLCJVc2VyIGdyb3VwIG1hbmFnZW1lbnQiLCJXZWJBZG1pbl9QYXNzQ2hlY2siLCJXZWJBZG1pbl9FbnRyYW5jZXNCeVpvbmVXaWRnZXQiLCJXZWJBZG1pbl9QYXJraW5nU3BhY2VNb25pdG9yaW5nIiwiV2ViQWRtaW5fQ2xpZW50R3JvdXBzX0VkaXQiLCJab25lIG1hbmFnZW1lbnQiLCJXZWJBZG1pbl9WaXNpdHNfRWRpdCIsIldlYkFkbWluX1Zpc2l0c19QYXNzTWFuYWdlbWVudCIsIldlYkFkbWluX0ltcG9ydCIsIldlYkFkbWluX1BhcmtpbmdPY2N1cGFuY3lTdGF0aXN0aWNzIiwiV2ViU2VydmljZV9TZXNzaW9uU3RvcHBlZCIsIldlYlNlcnZpY2VfUGF5bWVudFVwZGF0ZWQiLCJUcmFuc2xhdGlvbiBlZGl0b3IiLCJTZXR0aW5ncyBtYW5hZ2VtZW50IiwiRXZlbnQgdGlja2V0IHByaW50aW5nIiwiU3lzdGVtIGV2ZW50IGxvZyIsIk9wZXJhdG9yIGxvZyIsIlN5c3RlbSBzdGF0aXN0aWNzIiwiWCBhbmQgWiByZXBvcnQiLCJHdWFyZGlhbiBtb2R1bGUiLCJDYXNoaWVyIG1vZHVsZSIsIlBheW1lbnQgbG9nIiwiRGlzY291bnRlciBtb2R1bGUiLCJUYXJpZmYgY2hhcnQgYWNjZXNzIiwiRGVsZXRlIGNsaWVudCIsIkVkaXQgY2xpZW50IiwiVGFyaWZmIGNhbGN1bGF0b3IgYWNjZXNzIiwiV2ViU2VydmljZV9HZXRQcm9kdWN0c0J5R3JvdXAiLCJFeGNlcHRpb24gZGF5cyBtYW5hZ2VtZW50IiwiV2ViU2VydmljZV9DYW5jZWxDb250cmFjdCIsIkNvbnRyYWN0IG1hbmFnZW1lbnQiLCJUaW1ldGFibGUgbWFuYWdlbWVudCIsIlVzZXIgbWFuYWdlbWVudCIsIlZpc2l0b3IgbWFuYWdlbWVudCIsIldlYlNlcnZpY2VfR2V0U2VydmljZUZlZUJ5VGlja2V0SUQiLCJXZWJTZXJ2aWNlX1BheUZvclNlcnZpY2UiLCJUYXJpZmYgbWFuYWdlbWVudCIsIkV4aXQgdm91Y2hlciBwcmludGluZyIsIkJvb2tpbmcgbWFuYWdlbWVudCIsIk9uIHN0cmVldCBzdWJzY3JpcHRpb24gbWFuYWdlbWVudCIsIkNsaWVudCBncm91cCBtYW5hZ2VtZW50IiwiRGlzY291bnRlcl9DaGFuZ2VDYXJkR3JvdXAiLCJXZWJBZG1pbiBDaGVja1BheW1lbnRzIiwiV2ViQWRtaW4gcGFya2luZy9hY2Nlc3Mgd2lkZ2V0IiwiV2ViQWRtaW4gUHJvZHVjdHNTb2xkV2lkZ2V0IiwiV2ViQWRtaW4gUGFzc2VzQnlQYXNzR3JvdXBXaWRnZXQiLCJWaWV3Q2FyZHMiXSwiZXhwIjoxNzQwODQxMzAxLCJpc3MiOiJGaWRQYXJrIiwiYXVkIjoiRmlkUGFyayJ9.V2HU0XFei9gOvU_mXHMIEWR9dJJPmdysaJpRyk8qv5Q";
    // also I checked url for clients in postman and got the response 400, so I am not sure that the right API was used, but it's the only option which seems logical

// So, for AuthenticateAsync method POST request is sent and for GetClientsAsync methos GET request is sent. //
    public async Task<bool> AuthenticateAsync()
    {
        using (HttpClient client = new HttpClient())
        {
            var loginData = new { Username = "demo", Password = "Demo12345" };
            string jsonLoginData = JsonConvert.SerializeObject(loginData);
            var content = new StringContent(jsonLoginData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(loginUrl, content);

            if (response.IsSuccessStatusCode)
            {
                
                string jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                
                if (result?.Token != null)
                {
                    authToken = result.Token; 
                    return true;
                }
                else
                {
                    Console.WriteLine("Authentication response did not contain a valid token.");
                    return false;
                }
            }
            else
            {
                string errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Authentication failed: {response.StatusCode} - {errorContent}");
                return false;
            }
        }
    }

/* the problem is that I get an unauthorized error, so it seems that API is missing a valid authorization token.
Token is not expired for sure, login and password are correct*/
public async Task<List<Client>> GetClientsAsync()
{
    try
    {
        string requestUrl = $"{baseUrl}";
        Console.WriteLine($"Fetching clients from: {requestUrl}");

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(requestUrl);
            string jsonResponse = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                List<Client> clients = JsonConvert.DeserializeObject<List<Client>>(jsonResponse) ?? new List<Client>();
                Console.WriteLine($"{clients.Count} clients found.");
                return clients;
            }
            else
            {
                Console.WriteLine($"Error {response.StatusCode}: {jsonResponse}");
                return new List<Client>();
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception: {ex.Message}");
        return new List<Client>();
    }
}
}

