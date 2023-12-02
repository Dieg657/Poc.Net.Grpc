namespace Poc.Net.Grpc.Application.Models.Requests
{
    public class EmployeeRequestModel
    {
        public string Role { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool Remote { get; set; }
        public string Link { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
