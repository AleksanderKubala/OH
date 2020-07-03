using System;

namespace OHLogic.Common.Exceptions
{
    class ContextualStateWithoutContextException : NullReferenceException
    {
        public ContextualStateWithoutContextException() : base()
        {

        }

        public ContextualStateWithoutContextException(string message) : base(message)
        {

        }
    }
}
