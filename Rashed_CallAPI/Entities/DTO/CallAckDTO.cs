using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class CallAckDTO
    {
        public StatusDTO Status { get; set; }
        public CallAckDataDTO Data { get; set; }
    }
}
