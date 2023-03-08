namespace bikestore.Core.Entity
{
    public class ExecutionResult
    {
        /* 
    200 OK — This is most commonly used HTTP code to show that the operation performed is successful.
    201 CREATED — This can be used when you use POST method to create a new resource.
    202 ACCEPTED — This can be used to acknowledge the request sent to the server.
    400 BAD REQUEST — This can be used when client side input validation fails.
    401 UNAUTHORIZED / 403 FORBIDDEN — This can be used if the user or the system is not authorised to perform certain operation.
    404 NOT FOUND — This can be used if you are looking for certain resource and it is not available in the system.
    500 INTERNAL SERVER ERROR — This should never be thrown explicitly but might occur if the system fails.
    502 BAD GATEWAY — This can be used if server received an invalid response from the upstream server.
    */
        public enum StatusCode
        {
            OK = 200,
            CREATED = 201,
            ACCEPTED = 202,
            BAD_REQUEST = 400,
            UNAUTHORIZED = 401,
            FORBIDDEN = 403,
            NOT_FOUND = 404,
            INTERNAL_SERVER_ERROR = 500,
            BAD_GATEWAY = 502
        }


        public StatusCode Result { get; set; }

        /// <summary>
        /// throw a message for user
        /// </summary>
        public string UserMessage { get; set; }

        public ExecutionResult()
        {
            Result = StatusCode.OK;
        }

        public object DataOutput { get; set; }

        public object Data { get; set; }
    }
}

