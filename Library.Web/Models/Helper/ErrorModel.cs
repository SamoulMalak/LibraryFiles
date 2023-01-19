namespace Library.Web.Models.Helper
{
    public class ErrorModel
    {
        public string ErrorName { get; set; }
        public string ErrorDescription { get; set; }
        public string  ErrorInfo { get; set; }
        public string ActionRedirect { get; set; }
        public string ControllerRedirect { get; set; }
        /// <summary>
        /// the  button name that will redirect to action/controller redirect 
        /// </summary>
        public string ButtonName { get; set; }
    }
}
