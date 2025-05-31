using System;

namespace SaltStacker.Domain.Models.Setting
{
    public class ApplicationSetting
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime ChangeDateTime { get; set; }
    }
}
