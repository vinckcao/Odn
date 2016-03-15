﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Odn
{
    /// <summary>
    /// This exception is thrown if a problem on ABP initialization progress.
    /// </summary>
    [Serializable]
    public class OdnInitializationException : OdnException
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public OdnInitializationException()
        {

        }

        /// <summary>
        /// Constructor for serializing.
        /// </summary>
        public OdnInitializationException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        public OdnInitializationException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public OdnInitializationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
