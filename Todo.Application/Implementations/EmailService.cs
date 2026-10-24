using System;
using System.Collections.Generic;
using System.Text;
using Todo.Application.Constants;
using Todo.Application.Contracts;

namespace Todo.Application.Implementations
{
    public class EmailService(IHttpClientFactory clientFactory) : IEmailService
    {
        public async Task<bool> SendEmailAsync(string recipient)
        {
            using var httpClient = clientFactory.CreateClient(ApplicationConstants.EmailServiceClient);
            var response = await httpClient.GetAsync($"/email/send?recipient={recipient}");

            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
