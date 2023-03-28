﻿using SuperStore.Data.Models;

namespace SuperStoreAPI.Views
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}