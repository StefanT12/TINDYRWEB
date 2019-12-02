using System.Collections.Generic;
using System.Linq;


namespace Application.Common.Models
{
    public class Result
    {
        internal Result(bool succeeded, string error)
        {
            Succeeded = succeeded;
            Error = error;
        }

        public bool Succeeded { get; set; }

        public string Error { get; set; }

        public static Result Success()
        {
            return new Result(true, null);
        }

        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }
}
