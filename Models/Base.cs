using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Base
    {
        [DataType(DataType.Upload)]
        public int BaseIntegger { get; set; }
    }
}
