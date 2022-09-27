using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using System;

namespace ProyectoIdentity.Servicios
{
    public class MailJetEmailSender : IEmailSender
    {
        private readonly IConfiguration configuration;
        public OpcionesMailJet opcionesMailJet;

        public MailJetEmailSender(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            opcionesMailJet = configuration
                .GetSection("MailJet").Get<OpcionesMailJet>();

            MailjetClient client = new MailjetClient(opcionesMailJet.ApiKey, opcionesMailJet.SecretKey);

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                    new JObject {
                        {
                            "From",
                            new JObject {
                                {"Email", "wilsonoquendo@proton.me"},
                                {"Name", "Wilson Oquendo"}
                            }
                        },
                        {
                            "To",
                            new JArray {
                            new JObject {
                                    {
                                        "Email",
                                        email
                                    },
                                    {
                                        "Name",
                                        "Wilson"
                                    }
                                }
                            }
                        },

                        {
                            "Subject",
                            subject
                        },
                            {
                                "HTMLPart",
                                htmlMessage
                            }
                    }
             });
            await client.PostAsync(request);

        }
    }
}