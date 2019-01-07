using System;
using System.Collections.Generic;

namespace AngularPOC.Common
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Messages = new List<string>();
        }

        public bool IsSuccess { get; set; }

        public IList<string> Messages { get; set; }
    }

    public class ApiResponse<TEntity> : BaseResponse 
    {
        public ApiResponse()
        {
            Data = new List<TEntity>();
        }

        public IList<TEntity> Data { get; set; }
    }
}
