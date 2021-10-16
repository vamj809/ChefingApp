namespace ChefingApp.Models
{
    public class NavigationParams
    {
        public string DestinationPage { get; set; }
        public string ParameterName { get; set; }
        public object ParameterObject { get; set; }
        public bool IsModal { get; set; }

        public NavigationParams(string destinationPage, string parameterName = null, object parameterObject = null, bool isModal = false)
        {
            DestinationPage = destinationPage;
            ParameterName = parameterName;
            ParameterObject = parameterObject;
            IsModal = isModal;
        }
    }
}
