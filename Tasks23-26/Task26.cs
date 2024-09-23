using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tasks23_26
{
    namespace Task26
    {
        /* 
            * Author : Ciobanu Stanislav
            * Date : 20.09.2024
            * Task : Exercise 26 from .Net home work
        */


        /*
            * This class represents User as an object
            * Contains name and email address as properties
            * Method GetEmail recieves an email and prints it's content on screen
            * Method create email creates an Email object with optional content (body property) 
                    and current user's reference
         */
        public class User
        {
            private String name { get; set; }
            public String emailAddress { get; set; }

            public User(String name, String emailAddress)
            {
                this.name = name;
                this.emailAddress = emailAddress;
            }

            public void GetEmail(in Email email)
            {
                Console.WriteLine($"\nUser {name} recieved new email:");
                Console.WriteLine($"Author : {email.sender.name}");
                Console.WriteLine($"Message : {email.body}");
            }

            public Email CreateEmail(String body)
            {
                return new Email(this, body);
            }
        }

        /*
            * This class represents email as an object.
            * Contains body with all the content and email of sender
         */

        public class Email
        {
            public User sender { get; set; }
            public string body { get; set; }

            public Email(User sender, string message)
            {
                this.sender = sender;
                this.body = message;
            }
        }

        /*
            * This class represents a service that sends emails
            * Singleton
            * Contains field emailRegex for checking email addresses for corresponding to a pattern
            * User system sends email to sender if service gets LongBodyException during the Validation
         */

        sealed public class EmailService
        {
            private static EmailService? _instance;
            public static EmailService Instance
            {
                get
                {
                    _instance ??= new EmailService();

                    return _instance;
                }
            }

            private User system { get; init; }
            private Regex emailRegex { get; init; }

            private EmailService()
            {
                system = new User("EmailService", "EmailService@endava.com");
                emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            }


            /* 
                * Recieves email and recepient of this email 
                * Calls Validate method to check if email's body and recepient's email address are right
                * If catches Exception does actions depending on type of Exception
                * If catches no Exceptions sends email
             */

            public void SendEmail(Email email, User recipient)
            {
                try
                {
                    ValidateEmail(email, recipient);
                    recipient.GetEmail(email);
                }
                catch (LongBodyException ex)
                {
                    Console.WriteLine(ex.Message);

                    for (int i = 0; i < email.body.Length; i += 100) 
                    {
                        recipient.GetEmail(new Email(system, email.body.Substring(i, Math.Min(100, email.body.Length - i))));
                    }
                }
                catch (EmailInvalidException ex)
                {
                    Console.WriteLine(ex.Message);
                    email.sender.GetEmail(new Email(system, "Invalid email address"));
                }
            }

            /*  
                * Recives email and recepient of this email
                * Validates if email's body is shorter than 100 symbols
                * Validates if recepient's email address is correct according to regular expression pattern
                * Throws exception if Validation is failed
                * Returns void
            */
            private void ValidateEmail(Email email, User recipient)
            {
                if (email.body.Length >= 100)
                {
                    throw new LongBodyException();
                }

                if (!emailRegex.IsMatch(recipient.emailAddress))
                {
                    throw new EmailInvalidException();
                }
            }

            /*  
                * Throws ServiceUnavialable exception
            */
            public void ServiceUnavialableThrow()
            {
                throw new ServiceUnavailableException();
            }
        }


        /*  
            * Throw if email address of recepient does not correspond to regular expression pattern
        */
        public class EmailInvalidException : Exception
        {
            public EmailInvalidException() : base("Invalid email") { }
            public EmailInvalidException(string message) : base(message) { }
        }

        /*  
            * Throw if email's body is longer than 100 symbols
        */
        public class LongBodyException : Exception
        {
            public LongBodyException() : base("Email body is too long") { }
            public LongBodyException(string message) : base(message) { }
        }

        /*  
            * Throw if email service is unavialable for some reasons
        */
        public class ServiceUnavailableException : Exception
        {
            public ServiceUnavailableException() : base("Service is unavialable") { }
            public ServiceUnavailableException(string message) : base(message) { }
        }

    }
}