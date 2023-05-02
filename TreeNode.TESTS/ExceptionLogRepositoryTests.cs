using Microsoft.EntityFrameworkCore;
using NodeTree.DB;
using NodeTree.DB.Entities;
using NodeTree.INFRASTRUCTURE.DTOs;
using NodeTree.INFRASTRUCTURE.Repositories.Concrete;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NodeTree.TESTS
{
    [TestFixture]
    public class ExceptionLogRepositoryTests
    {
        private NodeTreeDbContext _context;
        private ExceptionLogRepository _repository;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<NodeTreeDbContext>()
                .UseInMemoryDatabase(databaseName: "NodeTreeTestDb")
                .Options;

            _context = new NodeTreeDbContext(options);

            _context.ExceptionsLog.AddRange(
                new ExceptionLog
                {
                    Type = "error",
                    Message = "Test 1",
                    CreatedAt = DateTime.UtcNow.AddDays(-2),
                    StackTrace = "test"
                },
                new ExceptionLog
                {
                    Type = "SecureException",
                    Message = "Test 2",
                    CreatedAt = DateTime.UtcNow.AddDays(-4),
                    StackTrace = "test"
                },
                new ExceptionLog
                {
                    Type = "SecureException",
                    Message = "Test 3",
                    CreatedAt = DateTime.UtcNow.AddDays(-6),
                    StackTrace = "test"
                }
            );
            _context.SaveChangesAsync().GetAwaiter().GetResult();

            _repository = new ExceptionLogRepository(_context);
        }
               
        [Test]
        public async Task GetExceptionLogAndCountFromDateToDateAndTakeAmout_ReturnsCorrectCountForSecureExeption()
        {
            // Act
            var result = await _repository.GetExceptionLogAndCountFromDateToDateAndTakeAmout("SecureException",
                DateTime.UtcNow.AddDays(-15),
                DateTime.UtcNow,
                0,
                5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetExceptionLogAndCountFromDateToDateAndTakeAmout_ReturnsCorrectCountForSecureExeption_ReturnsCorrectCountForSecureExeption_WhenOneExceptionIsNotInDateRange()
        {
            // Act
            var result = await _repository.GetExceptionLogAndCountFromDateToDateAndTakeAmout("SecureException",
                DateTime.UtcNow.AddDays(-5),
                DateTime.UtcNow,
                0,
                5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GetExceptionLogAndCountFromDateToDateAndTakeAmout_ReturnsCorrectCountForSecureExeption_ReturnsCorrectCountForSecureExeption_WhenDatesAreNull()
        {
            // Act

            var result = await _repository.GetExceptionLogAndCountFromDateToDateAndTakeAmout("SecureException",
                null,
                null,
                0,
                5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetExceptionLogAndCountFromDateToDateAndTakeAmout_ReturnsCorrectCountForSecureExeption_ReturnsCorrectCountForSecureExeption_WhenFromDateIsNull()
        {
            // Act

            var result = await _repository.GetExceptionLogAndCountFromDateToDateAndTakeAmout("SecureException",
                null,
                DateTime.UtcNow,
                0,
                5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public async Task GetExceptionLogAndCountFromDateToDateAndTakeAmout_ReturnsCorrectCountForSecureExeption_ReturnsCorrectCountForSecureExeption_WhenToDateIsNull()
        {
            // Act

            var result = await _repository.GetExceptionLogAndCountFromDateToDateAndTakeAmout("SecureException",
                DateTime.UtcNow.AddDays(-8),
                null,
                0,
                5);

            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeletedAsync();
        }

    }
}
