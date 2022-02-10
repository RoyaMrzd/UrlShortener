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
    public class UrlShortenerListQueryHandler : IRequestHandler<UrlShortenerListRequestQuery, IEnumerable<UrlShortenerListResultQuery>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlShortenerListQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;  
        }
        public async Task<IEnumerable<UrlShortenerListResultQuery>> Handle(UrlShortenerListRequestQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.UrlShorteners.GetAll();

            var mapper = InitializeAutomapper();
            var urlShorteners = mapper.Map<IEnumerable<UrlShortenerListResultQuery>>(list);
            return urlShorteners;

        }

        static Mapper InitializeAutomapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<UrlShortenerEntity, UrlShortenerListResultQuery>();
            });

            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
