﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ZF_AuditoriaCalidad.Client.Helpers
{
    public class HttpClientSinToken
    {       
        public HttpClientSinToken(HttpClient client)
        {
            Client = client;
        }
        public HttpClient Client { get; }
    }
}
