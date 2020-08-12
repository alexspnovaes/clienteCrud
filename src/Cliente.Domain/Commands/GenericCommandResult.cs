using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Cliente.Domain.Commands
{
    public class GenericCommandResult 
    {
        internal GenericCommandResult(bool ok, IEnumerable<string> erros, object data)
        {
            Ok = ok;
            Errors = erros.ToArray();
            Data = data;
        }

        internal GenericCommandResult(bool ok, IList<ValidationFailure> erros)
        {
            Ok = ok;
            Errors = erros.Select(x => x.ErrorMessage).ToArray();
            Data = null;
        }

        public GenericCommandResult()
        {
        }

        public bool Ok { get; set; }

        public string[] Errors { get; set; }

        public object Data { get; set; }

        public static GenericCommandResult Success(object data = null)
        {
            return new GenericCommandResult(true, new string[] { }, data);
        }

        public static GenericCommandResult Failure(IEnumerable<string> errors)
        {
            return new GenericCommandResult(false, errors, null);
        }

        public static GenericCommandResult Failure(IList<ValidationFailure> erros)
        {
            return new GenericCommandResult(false, erros);
        }
    }
}
