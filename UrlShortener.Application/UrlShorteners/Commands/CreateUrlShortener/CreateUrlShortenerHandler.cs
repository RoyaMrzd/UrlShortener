
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

namespace UrlShortener.Application.UrlShorteners.Commands.CreateUrlShortener
{
    public class CreateUrlShortenerHandler : IRequestHandler<CreateUrlShortener, CreateUrlShortenerResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUrlShortenerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUrlShortenerResult> Handle(CreateUrlShortener request, CancellationToken cancellationToken)
        {
            var urls = _unitOfWork.UrlShorteners.GetAll().Result;

            if (urls.Any(u => u.MainUrl == request.Url))
                throw new DuplicatedException("این آدرس قبلا وارد شده است");

            if (urls.Any(u => u.ShortestUrl == request.Url))
                throw new DuplicatedException("این آدرس کوتاه شده است");

            string token ="";
            do
            {
                token = GenerateToken();
            } while (urls.Any(x => x.Token == token));

            var entity = new UrlShortenerEntity()
            {
                Token = token,
                MainUrl = request.Url,
                ShortestUrl = new UrlShortenerConfig().Config.BASE_URL + token,
            };

            await _unitOfWork.UrlShorteners.Add(entity);
            await _unitOfWork.CommitChanges(cancellationToken);

            return new CreateUrlShortenerResult()
            {
                ShortestUrl = entity.ShortestUrl
            };
        }

 
        private string GenerateToken()
        {
            string urlsafe = string.Empty;
            Enumerable.Range(48, 75).Where(i => i < 58 || i > 64 && i < 91 || i > 96).OrderBy(o => new Random().Next()).ToList().ForEach(i => urlsafe += Convert.ToChar(i));
            string token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
            return token;
        }

    }
}
