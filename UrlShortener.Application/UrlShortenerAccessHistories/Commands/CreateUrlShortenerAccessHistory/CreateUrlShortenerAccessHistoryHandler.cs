
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Application.Common.AppConfig;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence.Interfaces;

namespace UrlShortener.Application.UrlShorteners.Commands.UrlShortenerAccessHistories
{
    public class CreateUrlShortenerAccessHistoryHandler : IRequestHandler<CreateUrlShortenerAccessHistory, CreateUrlShortenerAccessHistoryResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUrlShortenerAccessHistoryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUrlShortenerAccessHistoryResult> Handle(CreateUrlShortenerAccessHistory request, CancellationToken cancellationToken)
        {
            var entity = new UrlShortenerAccessHistory()
            {
                UrlShortenerEntityId = request.UrlShortenerEntityId
            };

            await _unitOfWork.UrlShortenerAccessHistories.Add(entity);
            await _unitOfWork.CommitChanges(cancellationToken);

            return new CreateUrlShortenerAccessHistoryResult()
            {
                Id = entity.Id
            };
        }

    }
}
