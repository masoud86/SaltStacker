using System;

namespace SaltStacker.Domain.Models.Setting
{
    public class Country
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public DateTime EditDateTime { get; set; }
    }
}
