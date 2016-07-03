using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odn
{
    /// <summary>
    /// Base exception type for those are thrown by Abp system for Abp specific exceptions.
    /// </summary>
    [Serializable]
    public class OdnException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="OdnException"/> object.
        /// </summary>
        public OdnException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="OdnException"/> object.
        /// </summary>
        public OdnException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="OdnException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public OdnException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="OdnException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public OdnException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }

    public class OdnFrameworkException : OdnException
    {
        public OdnFrameworkException(string message, Exception innerException = null) : base(message, innerException)
        {

        }
    }
}
