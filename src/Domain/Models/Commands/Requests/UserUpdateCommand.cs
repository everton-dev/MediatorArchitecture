using Domain.Models.Commands.Responses;
using MediatR;
using System;

namespace Domain.Models.Commands.Requests
{
    public class UserUpdateCommand : IRequest<UserResponse>
    {
        public int UserId { get; private set; }
        public short TypeDocument { get; private set; }
        public string DocumentNumber { get; private set; }
        public string InitialName { get; private set; }
        public string MiddleName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateBirth { get; private set; }
        public string Email { get; private set; }

        public UserUpdateCommand(int userId, short typeDocument, string documentNumber, string initialName, string middleName, string lastName, DateTime dateBirth, string email)
        {
            UserId = userId;
            TypeDocument = typeDocument;
            DocumentNumber = documentNumber;
            InitialName = initialName;
            MiddleName = middleName;
            LastName = lastName;
            DateBirth = dateBirth;
            Email = email;
        }
    }
}
