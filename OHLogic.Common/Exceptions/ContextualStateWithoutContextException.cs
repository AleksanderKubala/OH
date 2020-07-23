using System;

namespace Assets.Common.Exceptions
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
