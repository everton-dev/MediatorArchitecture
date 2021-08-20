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
}