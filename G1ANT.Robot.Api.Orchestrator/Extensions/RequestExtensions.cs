using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace G1ANT.Robot.Api.Orchestrator.Extensions
{
    public static class RequestExtensions
    {
        public static string GetBody(this HttpRequest request)
        {
            var body = string.Empty;
            request.EnableBuffering();
            request.Body.Position = 0;
            using (StreamReader stream = new StreamReader(request.Body))
            {
                var task = stream
                    .ReadToEndAsync()
                    .ContinueWith(t => {
                        body = t.Result;
                    });
                task.Wait();
            }
            return body;
        }
    }
}
