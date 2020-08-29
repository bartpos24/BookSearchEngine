using System;
using System.Collections.Generic;

using System.Text;

namespace BookSearchEngine.Domain.Common
{
    public class AuditableModel
    {
        public int CreatedById { get; set; }

        public DateTime CreatedDataTime { get; set; }

        public int? ModifiedById { get; set; }

        public DateTime? ModifiedDataTime { get; set; }
    }
}
