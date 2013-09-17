﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.ModelBinding;

namespace OpenBank
{
    public class AccountsService : NancyModule
    {
        public AccountsService()
        {
            Post["/accounts"] = parameters =>
            {
                var request = this.Bind<Parameters>();
                AccountInfoRequestParameters requestParameters = new AccountInfoRequestParameters()
                {
                    URL = request.url,
                    FID = request.fid,
                    ORG = request.org,
                    UserID = request.user_id,
                    Password = request.password
                };

                var fetcher = new AccountInfoRequestor(requestParameters);
                OfxResponse ofx = fetcher.FetchOfx();
                return ofx.Accounts;
            };
        }

        public class Parameters
        {
            [ParameterFormat("http://url.com/service")]
            public string url { get; set; }
            public string fid { get; set; }
            public string org { get; set; }
            public string user_id { get; set; }
            public string password { get; set; }
        }
    }
}