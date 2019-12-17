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
            var animals = _context.Animals.Include(a => a.User);
           var animal = await animals.FirstOrDefaultAsync(a => a.User.Username.Equals(request.OfUser));
            var animalVM = _mapper.Map<GetAnimalVM>(animal);

            return animalVM;
        }
    }
}
