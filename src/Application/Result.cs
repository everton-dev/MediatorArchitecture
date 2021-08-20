using Flunt.Notifications;
using System.Collections.Generic;

namespace Application
{
    public class Result : Notification
    {
        public static Result Ok = new Result();

        private List<string> _validations = new List<string>();
        public List<string> Validations { get { return _validations; } }
        public bool HasValidations => _validations.Count > 0;
        public Result() { }

        public void AddValidation(string validation) =>
            _validations.Add(validation);
    }

    public class Result<TResponse> : Result
    {
        public TResponse Data { get; private set; }
        public Result() { }
    }
}