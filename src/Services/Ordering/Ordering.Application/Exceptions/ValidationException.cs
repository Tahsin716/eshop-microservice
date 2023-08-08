using FluentValidation.Results;
using System.Runtime.Serialization;

namespace Ordering.Application.Exceptions
{
    [Serializable]
    public class ValidationException : ApplicationException, ISerializable
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        protected ValidationException(SerializationInfo info, StreamingContext context)
        : base(info, context)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

    }
}
