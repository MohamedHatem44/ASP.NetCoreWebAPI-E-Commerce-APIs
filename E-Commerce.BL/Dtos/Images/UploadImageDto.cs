namespace E_Commerce.BL.Dtos.Images
{
    public class UploadImageDto
    {
        /*------------------------------------------------------------------------*/
        public bool IsSuccess {  get; set; }
        public string Message { get; set; }
        public string URL { get; set; }
        /*------------------------------------------------------------------------*/
        public UploadImageDto(bool isSuccess, string message, string url = "")
        {
            IsSuccess = isSuccess;
            Message = message;
            URL = url;
        }
        /*------------------------------------------------------------------------*/
    }
}
