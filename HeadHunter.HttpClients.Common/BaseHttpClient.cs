﻿using HeadHunter.HttpClients.Common.Extensions;
using HeadHunter.Model.Common;
using System.Net;

namespace HeadHunter.HttpClients.Common
{
    public class BaseHttpClient : HttpClient
    {
        public BaseHttpClient(): base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {

        }

        public BaseHttpClient(string uri) : base(new HttpClientHandlerBuilder().WithAllowAutoRedirect().WithAutomaticDecompression()
            .UseCertificateCustomValidation().Build())
        {
            if (string.IsNullOrEmpty(uri))
            {
                throw new ArgumentNullException(nameof(uri));
            }

            BaseAddress = new Uri(uri);
        }

        public async Task<ResponseModel<string>> Get(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await (await GetAsync(query)).GetResponseModel();
        }

        public async Task<ResponseModel<T>> Get<T>(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await (await GetAsync(query)).GetResponseModel<T>();
        }

        public async Task<ResponseModel<T>> Post<T>(string query, object content)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await (await PostAsync(query, content.ToStringContent())).GetResponseModel<T>();
        }

        public async Task<ResponseModel<T>> Put<T>(string query, object content)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await (await PutAsync(query, content.ToStringContent())).GetResponseModel<T>();
        }

        public async Task<ResponseModel<T>> Delete<T>(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return await (await DeleteAsync(query)).GetResponseModel<T>();
        }

        public void UseHeaders(Dictionary<string, string> headers)
        {
            if (headers == null)
            {
                throw new ArgumentNullException(nameof(headers));
            }

            DefaultRequestHeaders.Clear();

            foreach (var header in headers)
            {
                DefaultRequestHeaders.Add(header.Key, header.Value);
            }
        }
    }
}
