﻿using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterIndustriesHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterIndustriesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetIndustriesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterIndustries.GetIndustriesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
