using Flunt.Notifications;
using System;

namespace Domain.Models
{
    public abstract record ModelBase
    {
        public bool Active { get; private set; }
        public string UserEntry { get; private set; }
        public DateTime DateEntry { get; private set; }

        public ModelBase()
        {
            Active = true;
            UserEntry = string.Empty;
            DateEntry = DateTime.Now;
        }

        public ModelBase(bool active, string userEntry, DateTime dateEntry)
        {
            Active = active;
            UserEntry = userEntry;
            DateEntry = dateEntry;
        }

        public void Register(string userEntry, DateTime dateEntry)
        {
            UserEntry = userEntry;
            DateEntry = dateEntry;
        }

        public void Activate() => Active = true;
        public void Inactivate() => Active = false;
    }
}