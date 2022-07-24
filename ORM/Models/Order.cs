using System;
using System.Collections.Generic;
using System.Text;

namespace ORM.Models
{
    public class Order : Entity
    {
        public byte Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public enum Status
    {
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Cancelled,
        Done
    }
}
