namespace BackendAPI.Dtos
{
    // Represents a registration request with username, password, and email.
    // This class is used to transfer data from the client to the server during user registration.
    public class RegisterRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; }
    }
    // Represents a login request with username and password.
    // This class is used to transfer data from the client to the server during user login.
    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}