using System.Collections.Generic;

namespace Domain.Models.Commands.Responses
{
    public class DefaultResponse
    {
        private List<string> _validations = new List<string>();
        public List<string> Validations { get { return _validations; } }
        public bool HasValidations => _validations.Count > 0;
        public DefaultResponse() { }

        public void AddValidation(string validation) =>
            _validations.Add(validation);
    }

    public class DefaultResponse<TResponse> : DefaultResponse
    {
        public TResponse Data { get; private set; }
        public DefaultResponse() { }
    }
}