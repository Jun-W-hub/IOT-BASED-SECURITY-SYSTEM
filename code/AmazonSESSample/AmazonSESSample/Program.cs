using System;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.IO;
using System.IO.Ports;

namespace AmazonSESSample
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort myport = new SerialPort();
            myport.BaudRate = 9600;
            myport.PortName = "COM7";
            myport.Open();

            // Replace sender@example.com with your "From" address. 
            // This address must be verified with Amazon SES.
            String FROM = "jwang46@masonlive.gmu.edu";
            String FROMNAME = "WJ";

            // Replace recipient@example.com with a "To" address. If your account 
            // is still in the sandbox, this address must be verified.
            String TO = "fredsun19950429@gmail.com";

            // Replace smtp_username with your Amazon SES SMTP user name.
            String SMTP_USERNAME = "AKIAXYFP5IUARY7IA7WY";

            // Replace smtp_password with your Amazon SES SMTP user name.
            String SMTP_PASSWORD = "BGU+oYOfd5O/nWL1SILmbjHtEOEjMJF49YvSEthCMfXM";



            // If you're using Amazon SES in a region other than 美国西部（俄勒冈）, 
            // replace email-smtp.us-west-2.amazonaws.com with the Amazon SES SMTP  
            // endpoint in the appropriate AWS Region.
            String HOST = "email-smtp.us-east-1.amazonaws.com";

            // The port you will connect to on the Amazon SES SMTP endpoint. We
            // are choosing port 587 because we will use STARTTLS to encrypt
            // the connection.
            int PORT = 587;

            // The subject line of the email
            String SUBJECT =
                "Amazon SES test (SMTP interface accessed using C#)";

            // The body of the email
            String BODY =
                "<h1>Alarm！！！</h1>" +
                // "<p>This email was sent through the " +
                //<a href='https://aws.amazon.com/ses'>Amazon SES</a> SMTP interface " +
                "somebody try to open your safe box , please check the monitor";

            // Create and build a new MailMessage object
            MailMessage message = new MailMessage();
            message.IsBodyHtml = true;
            message.From = new MailAddress(FROM, FROMNAME);
            message.To.Add(new MailAddress(TO));
            message.Subject = SUBJECT;
            message.Body = BODY;


            using (var client = new System.Net.Mail.SmtpClient(HOST, PORT))
            {
                // Pass SMTP credentials
                client.Credentials =
                    new NetworkCredential(SMTP_USERNAME, SMTP_PASSWORD);

                // Enable SSL encryption
                client.EnableSsl = true;

                // Try to send the message. Show status in console.

                while (true)
                {
                    String data_rx = myport.ReadLine();
                    if (Convert.ToChar(data_rx[0]) == '1')
                    {
                        {
                            Console.WriteLine("Attempting to send email...");
                            client.Send(message);
                            myport.WriteLine("1");
                            Console.WriteLine("Email sent!");
                        }

                    }
                }
            }
        }
    }
}