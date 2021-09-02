namespace Domain.Models.Commands.Responses
{
    public class UserResponse : DefaultResponse
    {
        public static UserResponse OK = new UserResponse();
        public bool Success { get; set; }
        public string Menssage { get; set; }

        public UserResponse()
        {
            Success = true;
            Menssage = string.Empty;
        }

        public UserResponse(bool success, string menssage)
        {
            Success = success;
            Menssage = menssage;
        }
    }

    public class UserResponse<TResponse> : UserResponse
    {
        public TResponse Data { get; private set; }
        public UserResponse() : base() { }

        public UserResponse(bool success, string menssage) 
            : base(success, menssage) 
        {
            Data = default(TResponse);
        }

        public UserResponse(bool success, string menssage, TResponse data)
            : base(success, menssage)
        {
            Data = data;
        }

        public UserResponse(TResponse data)
            : base()
        {
            Data = data;
        }
    }
}