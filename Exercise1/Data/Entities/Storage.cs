using System;
using System.ComponentModel.DataAnnotations;

namespace Exercise1
{
    [Serializable]
    public class Storage
    {
        [Key]
        public int Order { get; set; }
        public int Code { get; set; }
        public string Value { get; set; }

    }
}
