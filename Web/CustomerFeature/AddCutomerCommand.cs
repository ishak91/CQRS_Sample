using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.DataAccess;
using Web.Domain;

namespace Web.CustomerFeature
{
    public class AddCutomerCommand

    {
        public class AddCutomerRequest:IRequest<int>
        {
            public string Name { get; set; }
        }

        public class AddCutomerHandelr : IRequestHandler<AddCutomerRequest, int>
        {
            private readonly DatabaseContext _databaseContext;

            public AddCutomerHandelr(DatabaseContext databaseContext)
            {
                _databaseContext = databaseContext;
            }

            public async Task<int> Handle(AddCutomerRequest request, CancellationToken cancellationToken)
            {
                var customer = new Customer
                {
                    Name = request.Name
                };

                _databaseContext.Add(customer);
                await _databaseContext.SaveChangesAsync(cancellationToken);
                return customer.Id;
            }
        }

    }
}
