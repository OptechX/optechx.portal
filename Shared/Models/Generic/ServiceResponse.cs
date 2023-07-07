namespace OptechX.Portal.Shared.Models.Generic
{
	public class ServiceResponse<T>
	{
		public T? Data { get; set; }
		public bool Success { get; set; } = true;
		public string? Message { get; set; }
		public int ResponseCode { get; set; }
	}
}

