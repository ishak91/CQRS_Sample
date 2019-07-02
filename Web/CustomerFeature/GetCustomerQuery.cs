using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.DataAccess;

namespace Web.CustomerFeature
{
    public class GetCustomerQuery
    {
        public class GetCustomerRequest : IRequest<GetCustomerResponse>
        {
            public int Id { get; set; }
        }


        public class GetCustomerResponse
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class GetCustomerMapperProfile : AutoMapper.Profile
        {
            public GetCustomerMapperProfile() : base("GetCustomerProfile")
            {
                CreateMap<Domain.Customer, GetCustomerResponse>();
            }

        }

        public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
        {
            private readonly DatabaseContext _databaseContext;
            private readonly IMapper _mapper;

            public GetCustomerHandler(DatabaseContext databaseContext,IMapper mapper)
            {
                _databaseContext = databaseContext;
                _mapper = mapper;
            }
            public Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
            {
               return _databaseContext.Customers.Where(s => s.Id == request.Id).ProjectTo<GetCustomerResponse>(_mapper.ConfigurationProvider).SingleOrDefaultAsync();
            }
        }

    }

    

}
