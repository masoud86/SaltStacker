using System;

namespace SaltStacker.Domain.Models.Setting
{
    public class City
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public DateTime EditDateTime { get; set; }

        public int ProvinceId { get; set; }

        public virtual Province Province { get; set; }
    }
}
