namespace Poc.Net.Grpc.Application.Models.Responses
{
    public class EmployeeResponseModel
    {
        public int Id { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool Remote { get; set; }
        public string Link { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
