namespace Xem.Api
{
    public class ResponseBase
    {
        protected ResponseBase()
        { }

        public string Result { get; private set; }

        public object Data { get; private set; }

        public string Message { get; private set; }
    }
}
