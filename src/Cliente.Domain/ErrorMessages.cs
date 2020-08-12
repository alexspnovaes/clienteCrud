using System;
using System.Collections.Generic;
using System.Text;

namespace Cliente.Domain
{
    public class ErrorMessages
    {
        public static string IdEmpty = "O campo id deve ser preenchido";
        public static string NameEmpty = "O campo nome deve ser preenchido";
        public static string NameMoreThan100 = "O campo nome deve ser menor que 100 caracteres";
        public static string NameLessThan3 = "O campo nome deve ser maior que 3 caracteres";
        public static string AgeEmpty = "O campo idade deve ser preenchido";
        public static string AgeLessThan150 = "O campo idade deve ser menor que 150";
        public static string ClientNofFound = "Cliente não encontrado";
    }
}
