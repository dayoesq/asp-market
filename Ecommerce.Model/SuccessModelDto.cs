namespace Ecommerce.Model;

public class SuccessModelDto
{
    public int StatusCode { get; set; }
    public string ErrorMessage { get; set; }
    public object Data { get; set; }
}