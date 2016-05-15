using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odn.Authorizations
{
    /// <summary>
    /// This exception is thrown on an unauthorized request.
    /// </summary>
    [Serializable]
    public class AbpAuthorizationException : OdnException
    {
        /// <summary>
        /// Creates a new <see cref="AbpAuthorizationException"/> object.
        /// </summary>
        public AbpAuthorizationException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpAuthorizationException"/> object.
        /// </summary>
        public AbpAuthorizationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpAuthorizationException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public AbpAuthorizationException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="AbpAuthorizationException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public AbpAuthorizationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
