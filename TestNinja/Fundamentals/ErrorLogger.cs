
using System;

namespace TestNinja.Fundamentals
{
    public class ErrorLogger
    {
        public string LastError { get; set; }

        public event EventHandler<Guid> ErrorLogged;

        private Guid _errorId;
        
        public void Log(string error)
        {
            // null
            // ""
            // " "
            if (String.IsNullOrWhiteSpace(error))
                throw new ArgumentNullException();
                
            LastError = error;

            // Write the log to a storage
            // ...

            _errorId = Guid.NewGuid();

            onErrorLogged(_errorId);
        }

        protected virtual void onErrorLogged(Guid errorId)
        {
            ErrorLogged?.Invoke(this, errorId);
        }
    }
}