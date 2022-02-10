using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShorteners.Queries
{
    public class UrlShortenerListRequestQuery:IRequest<IEnumerable<UrlShortenerListResultQuery>>
    {
    }
}
