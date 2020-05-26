using System;
using System.Runtime.Serialization;

namespace Core.Helper
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string Exception { get; set; }
    }

    public class BaseResponse
    {
        public ErrorResponse ErrorResponse { get; set; } = new ErrorResponse();
    }

    public class BaseResponse<T> : BaseResponse
    {
        public bool HasError => !String.IsNullOrWhiteSpace(ErrorResponse.Message) || ErrorResponse.Exception != null;

        public T Result { get; set; }
    }
}
