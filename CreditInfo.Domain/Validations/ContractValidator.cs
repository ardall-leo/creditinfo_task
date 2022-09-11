using CreditInfo.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditInfo.Domain.Validations
{
    public class ContractValidator : AbstractValidator<Contract>
    {
        public ContractValidator()
        {
            RuleForEach(x => x.Individual).SetValidator(new IndividualValidator());

            RuleFor(x => new {
                x.ContractData.DateOfLastPayment,
                x.ContractData.NextPaymentDate,
                x.ContractData.DateAccountOpened }).Must((y) => BeBeforeDueDate(y.DateOfLastPayment, y.NextPaymentDate) && BeBeforeDueDate(y.DateAccountOpened, y.DateOfLastPayment));
           
            RuleFor(x => new
            {
                x.SubjectRole,
                x.ContractData.OriginalAmount
            }).Must(y => y.SubjectRole.Sum(z => z.GuaranteeAmount.Value) < y.OriginalAmount.Value)
            .WithMessage("Sum of guarantee amount must be lower than the contract originial amount");
        }

        private bool BeBeforeDueDate(DateTime? input, DateTime? dueDate)
        {
            return input < dueDate;
        }
    }
}
