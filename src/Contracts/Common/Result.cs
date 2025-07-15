using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Common
{
    /// <summary>
    /// Class representing a result of an operation, which can be either successful or failed.
    /// </summary>
    public class Result
    {

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public string? Error { get; }

        protected Result(bool isSuccess, string? error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Success() => new Result(true, null);
        public static Result Failure(string error) => new Result(false, error);
    }

    /// <summary>
    /// Class representing a result of an operation that returns a value of type T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : Result
    {
        public T? Value { get; }
        private Result(bool isSuccess, T? value, string? error) : base(isSuccess, error)
        {
            Value = value;
        }
        public static Result<T> Success(T value) => new Result<T>(true, value, null);
        public static new Result<T> Failure(string error) => new Result<T>(false, default, error);
    }

}
