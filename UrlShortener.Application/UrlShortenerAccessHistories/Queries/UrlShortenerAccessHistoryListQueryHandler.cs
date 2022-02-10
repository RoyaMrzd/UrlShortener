using AutoMapper;
using AutoMapper.QueryableExtensions;
using UrlShortener.Domain.Entities;
using UrlShortener.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Persistence.Interfaces;

namespace UrlShortener.Application.UrlShorteners.Queries
{
    public class UrlShortenerAccessHistoryListQueryHandler : IRequestHandler<UrlShortenerAccessHistoryListRequestQuery, UrlShortenerAccessHistoryListResultQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlShortenerAccessHistoryListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<UrlShortenerAccessHistoryListResultQuery> Handle(UrlShortenerAccessHistoryListRequestQuery request, CancellationToken cancellationToken)
        {
            int count = 0;
            var list = await _unitOfWork.UrlShorteners.GetAll();
            var shortestUrl = list.Where(x => x.ShortestUrl == request.ShortUrl).FirstOrDefault();

            if (shortestUrl != null)
            {
                var histories = await _unitOfWork.UrlShortenerAccessHistories.GetAll();
                count = histories.Where(x => x.UrlShortenerEntityId == shortestUrl.Id && x.CreationDateTime.Date >= request.FromDate.Date
                  && x.CreationDateTime.Date <= request.ToDate.Date).Count();
            }
            return new UrlShortenerAccessHistoryListResultQuery
            {
                ShortestCount = count
            };


        }

    }
}
