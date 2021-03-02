using System;
using Admin.Entity;

namespace Admin.DataLayer.Helper
{
    public class MakeResponse
    {
        public static Response CreateSuccessResponse(object[] data)
        {
            return new Response
            {
                IsSuccess = true,
                Data = data
            };
        }

        public static Response CreateErrorResponse(string errMessage)
        {
            return new Response
            {
                IsSuccess = false,
                ErrorMessage = errMessage,
                Data = null
            };
        }

        public static Response CreateErrorResponse(Exception exception)
        {
            return new Response
            {
                IsSuccess = false,
                ErrorMessage = exception.Message,
                Data = null,
                Exception = exception
            };
        }
    }
}
