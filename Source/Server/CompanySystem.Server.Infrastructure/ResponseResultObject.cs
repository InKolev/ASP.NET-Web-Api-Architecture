namespace CompanySystem.Server.Infrastructure
{
    public class ResponseResultObject
    {
        public ResponseResultObject(object data)
        {
            this.Success = true;
            this.ErrorMessage = null;
            this.Data = data;
        }

        public ResponseResultObject(bool success, string errorMessage, object data = null)
        {
            this.Success = success;
            this.ErrorMessage = errorMessage;
            this.Data = data;
        }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }

        public object Data { get; set; }
    }
}