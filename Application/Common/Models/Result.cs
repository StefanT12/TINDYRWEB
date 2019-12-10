using System.Collections.Generic;
using System.Linq;


namespace Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, int message)
        {
            Succeeded = succeeded;
            ResultMessage = message;
        }

        public bool Succeeded { get; set; }

        public int ResultMessage { get; set; }

        public static Result Success(int successMessage = 0)
        {
            return new Result(true, successMessage);
        }

        public static Result Failure(int error)
        {
            return new Result(false, error);
        }
    }
}
