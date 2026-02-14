using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public int UpdatedById { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
