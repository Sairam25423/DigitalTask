using System;

namespace DigitalTask.Models
{
    public class UserInput
    {
        public string MobileNumber { get; set; }
        public string MobileOtp { get; set; }
        public string Email { get; set; }
        public string EmailOtp { get; set; }
        public string Name { get; set; }
        public string PANNumber { get; set; }
        public DateTime DateofBirth { get; set; }
    }
}