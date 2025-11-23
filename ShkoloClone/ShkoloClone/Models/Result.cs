namespace ShkoloClone.Models
{
    /// <summary>
    /// Represents the result of an operation with success/failure status and a message
    /// </summary>
    /// <typeparam name="T">The type of data returned on success</typeparam>
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; private set; }

        private Result(bool isSuccess, string message, T? data = default)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Creates a successful result with optional data
        /// </summary>
        public static Result<T> Success(string message = "Operation completed successfully", T? data = default)
        {
            return new Result<T>(true, message, data);
        }

        /// <summary>
        /// Creates a failed result with an error message
        /// </summary>
        public static Result<T> Failure(string message)
        {
            return new Result<T>(false, message);
        }
    }

    /// <summary>
    /// Non-generic result for operations that don't return data
    /// </summary>
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        private Result(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static Result Success(string message = "Operation completed successfully")
        {
            return new Result(true, message);
        }

        public static Result Failure(string message)
        {
            return new Result(false, message);
        }
    }
}

