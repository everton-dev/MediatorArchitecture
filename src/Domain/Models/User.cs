using Domain.Models.ValueObject;
using System;

namespace Domain.Models
{
    public record User : ModelBase
    {
        public User(int userId, Document document, Name name, DateTime dateBirth, string email)
        {
            UserId = userId;
            Document = document;
            Name = name;
            DateBirth = dateBirth;
            Email = email;
        }

        public User(Document document, Name name, DateTime dateBirth, string email)
        {
            UserId = 0;
            Document = document;
            Name = name;
            DateBirth = dateBirth;
            Email = email;
        }

        public int UserId { get; init; }
        public Document Document { get; init; }
        public Name Name { get; init; }
        public DateTime DateBirth { get; init; }
        public string Email { get; init; }
    }
}