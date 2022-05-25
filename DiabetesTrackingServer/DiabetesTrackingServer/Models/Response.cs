using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Models
{
    public class Response
    {
        public int[] Outcome;

        public Response(int[] outcome)
        {
            this.Outcome = outcome;
        }
    }
}
