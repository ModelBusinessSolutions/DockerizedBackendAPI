using GenFu;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using Mapster;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace App.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

       private static async Task<List<T>> GenerateFakeData<T>(int count) where T : new()
        {
            var results = A.ListOf<T>(count);

            return await Task.FromResult(results);
            
        }
    }
}