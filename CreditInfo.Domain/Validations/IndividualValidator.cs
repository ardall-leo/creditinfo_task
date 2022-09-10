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
            RuleFor(x => x.DateOfBirth).NotEmpty().Must(x => (DateTime.Now.Year - x.Year) > 18 && (DateTime.Now.Year - x.Year) < 99);
        }
    }
}
