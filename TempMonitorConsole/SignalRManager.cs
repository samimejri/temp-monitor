namespace TempMonitorConsole
{
    using System;
    using Microsoft.AspNetCore.SignalR.Client;

    public class SignalRManager
    {
        HubConnection connection;
        public async void Connect()
        {
            connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:5001/tempHub")
            .Build();
            System.Net.ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            await connection.StartAsync();
            Console.WriteLine("SignalR Connection Started!");
        }

        public async void SendMessage(object message)
        {
            if (connection.State == HubConnectionState.Connected)
            {
                await connection.InvokeAsync<string>("SendMessage", message);
            }
            else
            {
                Console.WriteLine("Wait fo connection to extablish before sending message!");
            }
        }
    }
}