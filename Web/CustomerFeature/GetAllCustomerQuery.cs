using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Domain;

namespace Web.CustomerFeature
{
    public class GetAllCustomerQuery
    {
        public class GetAllCustomerRequest : IRequest<List<GetAllCustomerResposne>>
        {

        }

        public class GetAllCustomerResposne
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }     

      

        public class GetAllCustomerHandelr : IRequestHandler<GetAllCustomerRequest, List<GetAllCustomerResposne>>
        {
            private readonly DataAccess.DatabaseContext _databaseContext;
            private readonly IMapper _mapper;

            public GetAllCustomerHandelr(DataAccess.DatabaseContext databaseContext,IMapper mapper)
            {
                _databaseContext = databaseContext;
                _mapper = mapper;
            } 

            Task<List<GetAllCustomerResposne>> IRequestHandler<GetAllCustomerRequest, List<GetAllCustomerResposne>>.Handle(GetAllCustomerRequest request, CancellationToken cancellationToken)
            {
                return _databaseContext.Customers.ProjectTo<GetAllCustomerResposne>(_mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }

    public class GetAllCustomerMapperProfile : Profile
    {
        public GetAllCustomerMapperProfile()
        {
            CreateMap<Customer, GetAllCustomerQuery.GetAllCustomerResposne>();
        }
    }
}
