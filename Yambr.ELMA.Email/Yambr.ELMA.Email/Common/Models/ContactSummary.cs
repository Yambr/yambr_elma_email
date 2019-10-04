﻿using System;

namespace Yambr.ELMA.Email.Common.Models
{
    //TODO возможно нужно выпилить этот класс
    /// <summary>
    /// Сокращенный вид для храненя в письме
    /// </summary>
    public class ContactSummary
    {
        public ContactSummary() { }

        public ContactSummary(string normalizedEmail, Contact contact)
        {
            if (contact == null) throw new ArgumentNullException(nameof(contact));
            Email = normalizedEmail;
            Fio = contact.Fio;
        }

        public Contact Contact { get; set; }

        public string Fio { get; set; }

        public string Email { get; set; }
    }
}
