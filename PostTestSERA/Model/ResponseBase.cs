namespace PostTestSERA.Model
{
    public class ResponseBase
    {
        public ResponseBase() { }
        private string _message=string.Empty;
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        private int _transactionId = 0;
        public int TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }
    }
}
