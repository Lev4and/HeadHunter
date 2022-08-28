﻿using System.Net;

namespace HeadHunter.HttpClients.Tests.Resource
{
    public class HeadHunterLanguagesHttpClientTests
    {
        private readonly HttpContext _context;

        public HeadHunterLanguagesHttpClientTests()
        {
            _context = new HttpContext();
        }

        [Fact]
        public async Task GetLanguagesAsync_ReturnSuccessResponseWithNotNullResult()
        {
            var response = await _context.Resource.HeadHunterLanguages.GetLanguagesAsync();
            var statusCode = response.Status.Code;

            Assert.NotNull(response);
            Assert.NotNull(response.Result);

            Assert.Equal(HttpStatusCode.OK, statusCode);
        }
    }
}
