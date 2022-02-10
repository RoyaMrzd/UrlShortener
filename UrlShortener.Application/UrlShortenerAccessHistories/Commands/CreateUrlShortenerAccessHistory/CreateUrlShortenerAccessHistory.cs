using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShorteners.Commands.UrlShortenerAccessHistories
{
    public class CreateUrlShortenerAccessHistory : IRequest<CreateUrlShortenerAccessHistoryResult>
    {
        public long UrlShortenerEntityId { get; set; }
    }
}
