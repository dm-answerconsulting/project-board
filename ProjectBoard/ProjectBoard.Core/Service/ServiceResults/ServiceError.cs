namespace ProjectBoard.Core.Service.ServiceResults
{
    public class ServiceError
    {
        #region .ctor

        public ServiceError()
        {
            
        }

        public ServiceError(string name, string message)
        {
            PropertyName = name;
            PropertyMessage = message;
        }

        #endregion

        public string PropertyName { get; set; }
        public string PropertyMessage { get; set; }
    }
}