using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CustomEntity.Request
{
    public class PowerBiReportRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ReportId { get; set; }
        public string WorkspaceId { get; set; }
    }
}
