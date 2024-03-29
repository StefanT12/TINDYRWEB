﻿using Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tindyr.Models.ProfileEdit
{
    public class UserProfileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public void Setup(UserProfileDetailsVM vm)
        {
            FirstName = vm.FirstName;
            LastName = vm.LastName;
            Email = vm.Email;
            PhoneNumber = vm.PhoneNumber;
        }

        public bool GetIfValid()
        {
            return FirstName != null && LastName != null && Email != null && PhoneNumber != null;
        }
    }
}
