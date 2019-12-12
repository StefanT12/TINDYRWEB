using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Animals.Queries
{
    public class GetAnimalHandler : IRequestHandler<GetAnimal, GetAnimalVM>
    {
        private readonly ITindyrDbContext _context;
        private readonly IMapper _mapper;
        public GetAnimalHandler(ITindyrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAnimalVM> Handle(GetAnimal request, CancellationToken cancellationToken)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.User.Username.Equals(request.OfUser));
            return _mapper.Map<GetAnimalVM>(animal);

        }
    }
}
