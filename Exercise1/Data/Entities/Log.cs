using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercise1
{
    public class Log
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public int Level { get; set; }
        public string Text { get; set; }

    }
}
