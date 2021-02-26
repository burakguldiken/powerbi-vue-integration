using Core.CustomEntity.Request;
using Core.CustomEntity.Response;
using Core.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.IServices
{
    public interface IPowerBiService
    {
        /// <summary>
        /// Get report
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IDataResult<GetReportInfoResponse> GetReportInfo(PowerBiReportRequest request);
    }
}
