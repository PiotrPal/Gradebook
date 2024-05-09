using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Domain.Exceptions {
    public abstract class GradebookException : Exception {
        public abstract HttpStatusCode StatusCode { get; }
        protected GradebookException(string massage) : base(massage) {

        }
    }
}
