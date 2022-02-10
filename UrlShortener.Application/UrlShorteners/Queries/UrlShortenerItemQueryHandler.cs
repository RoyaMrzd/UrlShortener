using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UrlShortener.Application.Common.Exceptions;
using UrlShortener.Persistence.Interfaces;

namespace UrlShortener.Application.UrlShorteners.Queries
{
    public class UrlShortenerItemQueryHandler : IRequestHandler<UrlShortenerItemRequestQuery, UrlShortenerItemResultQuery>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UrlShortenerItemQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UrlShortenerItemResultQuery> Handle(UrlShortenerItemRequestQuery request, CancellationToken cancellationToken)
        {
            var urlShorteners = await _unitOfWork.UrlShorteners.GetAll();
            var urlShortener = urlShorteners.Where(x => x.Token == request.Token).FirstOrDefault();

            if (urlShortener != null)
            {
                return new UrlShortenerItemResultQuery
                {
                    Id=urlShortener.Id,
                    ReturnUrl = urlShortener.MainUrl
                };
            }
            else
            {
                throw new NotFoundException("آدرس وارد شده موجود نمی باشد");
            }


        }
    }
}
