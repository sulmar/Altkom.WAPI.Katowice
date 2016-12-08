using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.RentBikes.Models.Validators
{
    public class StationValidator : AbstractValidator<Station>
    {
        public StationValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .Length(1, 5);

        }
    }
}
