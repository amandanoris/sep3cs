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
using DataClash.Application.Common.Exceptions;
using DataClash.Application.Common.Interfaces;
using DataClash.Application.Common.Security;
using DataClash.Domain.Entities;
using DataClash.Domain.Events;
using DataClash.Application.Matches.Commands.CreateMatch;
using MediatR;

namespace DataClash.Application.Matches.Commands.UpdateMatch
{
    [Authorize (Roles = "Administrator")]
    public record UpdateMatchCommand : IRequest
    {
        public long WinnerPlayerId { get; init; }
        public long LooserPlayerId { get; init; }
        public DateTime BeginDate { get; init; }
        public TimeSpan Duration { get; init; }
        public Player? LooserPlayer { get; init; }
        public Player? WinnerPlayer { get; init; }
    }

    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateMatchCommandHandler (IApplicationDbContext context)
        {
            _context = context;
        }
        private async Task<Player> GetPlayerById(long PlayerId,  CancellationToken cancellationToken)
        {
            var key = new object [] { PlayerId};
            var entity = await _context.Players.FindAsync (key, cancellationToken) ?? throw new NotFoundException (nameof (Player), key);
            return entity;
        }
        public async Task Handle (UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            DateTime ConvertedDate = request.BeginDate.AddHours(-5);
            var key = new object [] { request.LooserPlayerId, request.WinnerPlayerId, ConvertedDate };
            
            var entity = await _context.Matches.FindAsync (key, cancellationToken) ?? throw new NotFoundException (nameof (Match), key);
            
            entity.WinnerPlayerId = request.WinnerPlayerId;
            entity.LooserPlayerId = request.LooserPlayerId;
            entity.BeginDate = ConvertedDate;
            entity.Duration = request.Duration;
            entity.WinnerPlayer = GetPlayerById(request.WinnerPlayerId,cancellationToken).GetAwaiter().GetResult();
            entity.LooserPlayer = GetPlayerById(request.LooserPlayerId,cancellationToken).GetAwaiter().GetResult();
            
            entity.WinnerPlayer.AddDomainEvent (new MatchUpdatedEvent (entity));
            entity.LooserPlayer.AddDomainEvent (new MatchUpdatedEvent (entity));
            
            await _context.SaveChangesAsync (cancellationToken);
        }
    }
}