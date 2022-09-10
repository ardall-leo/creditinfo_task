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
            RuleFor(x => new {
                x.ContractData.DateOfLastPayment,
                x.ContractData.NextPaymentDate,
                x.ContractData.DateAccountOpened }).Must((y) => BeBeforeDueDate(y.DateOfLastPayment, y.NextPaymentDate) && BeBeforeDueDate(y.DateAccountOpened, y.DateOfLastPayment));

            RuleFor(x => new
            {
                x.SubjectRole.GuaranteeAmount,
                x.ContractData.OriginalAmount
            }).Must(y => y.GuaranteeAmount < y.OriginalAmount.Value);
        }

        private bool BeBeforeDueDate(DateTime? input, DateTime? dueDate)
        {
            return input < dueDate;
        }
    }
}
