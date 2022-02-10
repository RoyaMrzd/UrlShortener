using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener.Application.UrlShorteners.Commands.CreateUrlShortener
{
    public class CreateUrlShortenerCommand : IRequest<CreateUrlShortenerResult>
    {
        public string Url { get; set; }
    }
}
