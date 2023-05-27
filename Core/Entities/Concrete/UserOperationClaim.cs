using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid OperationClaimID { get; set; }
    }
}
