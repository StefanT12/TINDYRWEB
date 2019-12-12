using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Pictures.Queries;
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
            var animalVM = _mapper.Map<GetAnimalVM>(animal);

            animalVM.Pictures = new HashSet<PictureVM>();

            foreach (var pict in animal.Pictures)
            {
                animalVM.Pictures.Add(_mapper.Map<PictureVM>(pict));//convert all other pictures
            }

            animalVM.FrontPicture = _mapper.Map<PictureVM>(animal.FrontPicture);//convert front picture

            return animalVM;
        }
    }
}
