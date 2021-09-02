using Domain.Models.Commands.Responses;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Domain.Models.Commands.Requests
{
    public class UserCreateCommand : ValidateCommand, IRequest<UserResponse>
    {
        public short TypeDocument { get; set; }
        public string DocumentNumber { get; set; }
        public string InitialName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Email { get; set; }
        public string UserEntry { get; set; }

        public UserCreateCommand(short typeDocument, string documentNumber, string initialName, string middleName, string lastName, DateTime dateBirth, string email, string userEntry)
        {
            TypeDocument = typeDocument;
            DocumentNumber = documentNumber;
            InitialName = initialName;
            MiddleName = middleName;
            LastName = lastName;
            DateBirth = dateBirth;
            Email = email;
            UserEntry = userEntry;
        }

        public override async Task Validate()
        {
            await Task.Run(() =>
            {
                if (TypeDocument <= 0)
                    AddNotification("TypeDocument", "TypeDocument is required.");

                if (string.IsNullOrWhiteSpace(DocumentNumber))
                    AddNotification("DocumentNumber", "DocumentNumber is required.");

                if (string.IsNullOrWhiteSpace(InitialName))
                    AddNotification("InitialName", "InitialName is required.");

                if (string.IsNullOrWhiteSpace(MiddleName))
                    AddNotification("MiddleName", "MiddleName is required.");

                if (string.IsNullOrWhiteSpace(LastName))
                    AddNotification("LastName", "LastName is required.");

                if (DateBirth == DateTime.MinValue)
                    AddNotification("DateBirth", "DateBirth is required.");

                if (string.IsNullOrWhiteSpace(Email))
                    AddNotification("Email", "Email is required.");

                if (string.IsNullOrWhiteSpace(UserEntry))
                    AddNotification("UserEntry", "UserEntry is required.");
            });
        }
    }
}