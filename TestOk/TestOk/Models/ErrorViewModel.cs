using System;

namespace TestOk.Models
{
    public class ErrorViewModel: IBasicModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
