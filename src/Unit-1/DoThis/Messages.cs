﻿namespace WinTail
{
    public class Messages
    {
        #region Neutral/system Messages
        /// <summary>
        /// Marker class to continue processing.
        /// </summary>
        public class ContinueProcessing { }
        #endregion

        #region Success Messages
        // in Messages.cs
        /// <summary>
        /// Base class for signalling that user input was valid.
        /// </summary>
        public class InputSuccess
        {
            public InputSuccess(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; private set; }
        }
        #endregion

        #region Error Messages
        /// <summary>
        /// Base class for signalling that user input was invalid.
        /// </summary>
        public class InputError
        {
            public InputError(string reason)
            {
                Reason = reason;
            }

            public string Reason { get; private set; }
        }

        /// <summary>
        /// User provided blank input.
        /// </summary>
        public class NullInputError : InputError
        {
            public NullInputError(string reason) : base(reason) { }
        }

        /// <summary>
        /// User provided invalid input (currently, input w/ odd # chars)
        /// </summary>
        public class ValidationError : InputError
        {
            public ValidationError(string reason) : base(reason) { }
        }
        #endregion
    }
}
