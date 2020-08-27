using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Supplier.Api.Shared.OutputModel
{
    [Serializable]
    public class ApiException : Exception
    {
        public int StatusCode { get; set; }
        public string ResourceReferenceProperty { get; set; }

        public ApiException(Exception innerException, int statusCode = 500) : base(innerException?.Message, innerException)
        {
            if (innerException == null)
                throw new Exception("Unable to propagate exception message");
            StatusCode = statusCode;
        }

        protected ApiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            ResourceReferenceProperty = info.GetString("ResourceReferenceProperty");
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new ArgumentNullException("info");
            info.AddValue("ResourceReferenceProperty", ResourceReferenceProperty);
            base.GetObjectData(info, context);
        }
    }
}
