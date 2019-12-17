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
                animal.LookingFor = request.LookingFor;
                
                await _context.SaveChangesAsync(cancellationToken);
                return Result.Success();
            }

            return Result.Failure(ResultErrors.AnimalDoesntExist);
        }
    }
}
