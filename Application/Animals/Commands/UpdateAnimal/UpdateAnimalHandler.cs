using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Animals.Commands
{
    public class UpdateAnimalHandler : IRequestHandler<UpdateAnimal, Result>
    {
        ITindyrDbContext _context;
        public UpdateAnimalHandler(ITindyrDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(UpdateAnimal request, CancellationToken cancellationToken)
        {
            var animal = await _context.Animals.SingleOrDefaultAsync(a => a.UserId == request.UserId);

            if(animal != null)
            {
                animal.AnimalBreed = request.AnimalBreed;
                animal.AnimalDateOfBirth = request.AnimalDateOfBirth;
                animal.AnimalGender = request.AnimalGender;
                animal.AnimalName = request.AnimalName;
                animal.AnimalType = request.AnimalType;
                
                animal.Pictures = new HashSet<Picture>();

                if (!request.FrontPicture.Equals(""))
                {
                    animal.FrontPicture = new Picture { FileName = request.FrontPicture, Animal = animal };
                }
                
                if (request.PicturesName != null)
                {
                    foreach (var newPict in request.PicturesName)
                    {
                        animal.Pictures.Add(new Picture { Animal = animal, FileName = newPict });
                    }
                }
                
                
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }

            return Result.Failure(ResultErrors.AnimalDoesntExist);
        }
    }
}
