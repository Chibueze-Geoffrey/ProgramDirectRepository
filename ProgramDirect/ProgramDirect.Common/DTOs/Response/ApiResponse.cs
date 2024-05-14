using ProgramDirect.Common.Enums;

namespace ProgramDirect.Common.DTOs.Response
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public ApiResponseCode ResponseCode { get; set; }

        public static ApiResponse Response(string message, ApiResponseCode responseCode)
        {
            return new ApiResponse
            {
                Message = message,
                ResponseCode = responseCode
            };
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }

        public static ApiResponse<T> Response(T data, string message, ApiResponseCode responseCode)
        {
            return new ApiResponse<T>
            {
                Message = message,
                ResponseCode = responseCode,
                Data = data
            };
        }
    }
}
