using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Animals.Queries
{
    public class GetAnimalsHandler : IRequestHandler<GetAnimals, GetAnimalsListVM>
    {
        private readonly ITindyrDbContext _context;
        private readonly IMapper _mapper;
        public GetAnimalsHandler(ITindyrDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAnimalsListVM> Handle(GetAnimals request, CancellationToken cancellationToken)
        {
            var matchParam = request.AnimalMatchParam;

            var animDbList = await _context.Animals.Include(a => a.User).ToListAsync(cancellationToken);

            var animFoundList = new GetAnimalsListVM();

            foreach(var animal in animDbList)
            {
                var valid = await AllInfoValid(animal);
                
                if (valid)
                {
                    Animal animalFound = null;

                    if (request.ByGenderAndType)
                    {
                        var animalGender = request.OppositeGender ? (request.Gender.Equals("female", System.StringComparison.OrdinalIgnoreCase) ? "Male" : "Female") : request.Gender;

                        if (animal.AnimalType.Equals(request.Type) && animal.AnimalGender.Equals(animalGender))
                        {
                            animalFound = await AnimalHasMatchParam(animal, matchParam, request.ForUser);
                        }
                    }
                    else
                    {
                        animalFound = await AnimalHasMatchParam(animal, matchParam, request.ForUser);
                    }

                    if (animalFound != null)
                    {
                        var animalVM = _mapper.Map<GetAnimalVM>(animalFound);

                        animFoundList.Animals.Add(animalVM);

                    }
                }
            }

            //remove self
            var self = animFoundList.Animals.SingleOrDefault(a => a.User.Username.Equals(request.ForUser));
            if (self != null)
            {
                animFoundList.Animals.Remove(self);
            }

            return animFoundList;
        }

        public async Task<Animal> AnimalHasMatchParam(Animal animal, AnimalMatchParam matchParam, string forUser)
        {
            var match = new Match();
            switch (matchParam)
            {
                case AnimalMatchParam.UserIsLiked:
                    match = await _context.Matches.FirstOrDefaultAsync(m => m.User1.Equals(animal.User.Username) && m.User2.Equals(forUser) && m.User2LikedBack == false);
                    if (match != null)
                    {
                        return animal;
                    }
                    break;
                case AnimalMatchParam.Matched:
                    match = await _context.Matches.FirstOrDefaultAsync(m => (m.User2.Equals(animal.User.Username) || m.User1.Equals(animal.User.Username)) && m.User2LikedBack == true);
                    if (match != null)
                    {
                        return animal;
                    }
                    break;
                case AnimalMatchParam.Strangers:
                    match = await _context.Matches.FirstOrDefaultAsync(m => (!m.User2.Equals(animal.User.Username) || !m.User1.Equals(animal.User.Username)));
                    if (match == null)
                    {
                        return animal;
                    }
                    break;
                case AnimalMatchParam.UserLiked:
                    match = await _context.Matches.FirstOrDefaultAsync(m => m.User1.Equals(forUser) && m.User2LikedBack == false);
                    if (match != null)
                    {
                        return animal;
                    }
                    break;
            }
            return null;
        }

        public async Task<bool> AllInfoValid(Animal animal)
        {
            var profile = await _context.UserProfiles.SingleOrDefaultAsync(p => p.ProfileOf == animal.UserId);
            var animalValid = animal.AnimalName != null && animal.AnimalType != null && animal.AnimalGender != null && animal.AnimalBreed != null && animal.LookingFor != null;
            var profileValid = profile.Email != null && profile.FirstName != null && profile.LastName != null && profile.PhoneNumber != null;
            return profileValid && animalValid;
        }
    }
}
