using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagementModule.Domain.dto
{
    public class ApiResponse<T>
    {
        public Status Status { get; set; }

        public T Data { get; set; }

        public ApiResponse(Status status, T data)
        {
            Status = status;
            Data = data;
        }
    }
}
