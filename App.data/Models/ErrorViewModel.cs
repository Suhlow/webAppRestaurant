using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.data.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
