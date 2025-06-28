namespace Application.DTOs
{
    public class AuthResultDto
    {
        public bool Succeeded { get; set; }
        public string? Token { get; set; }
        public string? Error { get; set; }
        public List<string>? Errors { get; set; }
    }
}
