using ConsoleFluentValidationListParameter.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFluentValidationListParameter.Validator
{
    public class StudentListValidator:AbstractValidator<StudentInformationCollectionModel>
    {
        public StudentListValidator()
        {
            RuleForEach(x => x.StudentInformationList).SetValidator(new StudentValidator());
        }
    }
}
