/* Copyright (c) 2023-2025
 * This file is part of sep3cs.
 *
 * sep3cs is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * sep3cs is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with sep3cs. If not, see <http://www.gnu.org/licenses/>.
 */

using DataClash.Application.Common.Interfaces;
using MediatR;
using FluentValidation;

namespace DataClash.Application.Statistics.AllWarIds
{
   public record GetAllWarIdsQuery : IRequest<List<long>>;

   public class GetAllWarIdsQueryHandler : IRequestHandler<GetAllWarIdsQuery, List<long>>
   {
       private readonly IApplicationDbContext _context;

       public GetAllWarIdsQueryHandler(IApplicationDbContext context)
       {
           _context = context;
       }

       public async Task<List<long>> Handle(GetAllWarIdsQuery request, CancellationToken cancellationToken)
       {
           var allWarIds = _context.Wars.Select(w => w.Id).ToList();
           return allWarIds;
       }
   }

   public class GetAllWarIdsQueryValidator : AbstractValidator<GetAllWarIdsQuery>
   {
       public GetAllWarIdsQueryValidator()
       {
           // Add validation rules here
       }
   }
}
