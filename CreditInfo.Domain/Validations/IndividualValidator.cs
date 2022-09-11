using CreditInfo.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Validations
{
    public class IndividualValidator : AbstractValidator<Individual>
    {
        public IndividualValidator()
        {
            RuleFor(x => x.Age).NotEmpty().Must(x => x >= 18 && x <= 99)
                .WithMessage("Individual.DateOfBirth attribute value must be between 18 and 99 years"); ;
        }
    }
}
