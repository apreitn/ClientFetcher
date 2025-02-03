# ClientFetcher
I decided to create a console application using C# and .Net, which Connects to the API, fetches the list of clients, and displays them in the console.
The program structure is quite clear, but I didn't come to the point where it actually works as intended. 

There are three program file: Client.cs file, which will hold the client data model, Program. cs, the main entry point of the application, where the list of clients is supposed to be displayed, and ApiService.cs to handle API requests. ApiService.cs has two main methods, AuthenticateAsync to perform authentication by sending a POST request with login credentials to an API endpoint, and GetClientsAsync method, which fetches a list of clients, handles authentication, processes the response, and returns a list of Clients. 

So, the problem which I faced and couldn't resolve is an unauthorized error, which probably points to invalid/expired token or incorrect endpoint/request. The token according to Swagger is not expired and the Request (get all clients) seems to be correct (at least I don't see other options which could be relevant). I tried to check the API for getting all client in Postman ans still got 401 Unauthorized as a response. 

All in all, I would be very grateful to hear any feedback from you about my solution ans thank You for Your time. 
