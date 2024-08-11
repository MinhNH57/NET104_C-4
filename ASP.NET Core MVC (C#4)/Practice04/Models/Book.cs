using System.ComponentModel.DataAnnotations.Schema;

namespace Practice04.Models
{
    public class Book
    {
        public Guid ID { get;set; }
        public string Title { get; set; }
        public int soTrang { get ; set; }

        public DateTime ngayxuatban { get; set; }
    }
}
