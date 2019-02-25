using Recruitment.Domain.Services;
using System;
using Xunit;
using Moq;
using Recruitment.Domain.Repository;
using RecruitmentAPI.Controllers;
using System.Threading.Tasks;
using RecruitmentAPI.Unit.Tests.MockObjects;
using Microsoft.AspNetCore.Mvc;
using NFluent;
using System.Collections.Generic;
using Recruitment.Domain.Entity;

namespace RecruitmentAPI.Unit.Tests
{
    public class RecruitmentTest
    {
        private readonly Mock<IService> _serviceMock;
        public MockRepository MockRepository { get; }
        Mock<IRepository> mockRecruitmentRepository = new Mock<IRepository>();
        public RecruitmentController recruitmentController;

        public RecruitmentTest ()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
            _serviceMock = MockRepository.Create<IService>();
            recruitmentController = new RecruitmentController(_serviceMock.Object);
        }

        [Fact]
        public async Task GetCandidates_ReturnsCandidateList ()
        {
            _serviceMock.Setup(x => x.GetAllCandidatesAsync())
                .Returns(Task.FromResult(MockObject.GetCandidates()));

            var actionResult = await recruitmentController.GetCandidates() as ActionResult;

            Check.That(((OkObjectResult)actionResult).StatusCode).Equals((int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCandidates_ReturnsNoContent()
        {
            List<Candidates> candidateList = null;
            _serviceMock.Setup(x => x.GetAllCandidatesAsync())
                .Returns(Task.FromResult(candidateList));

            var actionResult = await recruitmentController.GetCandidates() as ActionResult;
            Check.That(((NoContentResult)actionResult).StatusCode).Equals((int)System.Net.HttpStatusCode.NoContent);
            MockRepository.VerifyAll();
        }

        [Fact]
        public async Task AddCandidate_ReturnOkResult_WhenCreatingAValidCandidate ()
        {
            _serviceMock.Setup(m => m.AddCandidate(It.IsAny<Candidates>())).Returns(Task.FromResult(1));
            _serviceMock.Setup(m => m.GetAllCandidatesAsync()).Returns(Task.FromResult(MockObject.GetCandidates()));

            var result = await recruitmentController.AddCandidate(MockObject.GetNewCandidate());
            Assert.Equal((int)System.Net.HttpStatusCode.OK, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public async Task AddCandidate_ReturnsBadRequest_WhenUpdatingNullCandidate()
        {
            _serviceMock.Setup(m => m.AddCandidate(It.IsAny<Candidates>())).Returns(Task.FromResult(1));
            _serviceMock.Setup(m => m.GetAllCandidatesAsync()).Returns(Task.FromResult(MockObject.GetCandidates()));
            var result = await recruitmentController.AddCandidate(null);
            Assert.Equal((int)System.Net.HttpStatusCode.BadRequest, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public async Task GetCandidateDetails_ReturnsOkResult_forValidId()
        {
            _serviceMock.Setup(m => m.GetCandidateById(1)).Returns(Task.FromResult(MockObject.GetCandidateDetails()));
            var actionResult = await recruitmentController.GetCandidateById(1) as ActionResult;
            Check.That(((OkObjectResult)actionResult).StatusCode).Equals((int)System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetCandidateDetails_ReturnsNoContentFound()
        {
            Candidates candidateDetails = null;
            _serviceMock.Setup(m => m.GetCandidateById(0)).Returns(Task.FromResult(candidateDetails));
            var actionResult = await recruitmentController.GetCandidateById(0) as ActionResult;
            Check.That(((NoContentResult)actionResult).StatusCode).Equals((int)System.Net.HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task EditCandidate_ReturnTrue()
        {
            _serviceMock.Setup(m => m.UpdateCandidate(It.IsAny<Candidates>())).Returns(Task.FromResult(1));
            _serviceMock.Setup(m => m.GetAllCandidatesAsync()).Returns(Task.FromResult(MockObject.GetCandidates()));
            var result = await recruitmentController.UpdateCandidate(MockObject.GetNewCandidate()) as ActionResult;
            Assert.Equal((int)System.Net.HttpStatusCode.OK, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public async Task EditCandidate_ReturnFalse()
        {
            _serviceMock.Setup(m => m.UpdateCandidate(It.IsAny<Candidates>())).Returns(Task.FromResult(1));
            _serviceMock.Setup(m => m.GetAllCandidatesAsync()).Returns(Task.FromResult(MockObject.GetCandidates()));
            var result = await recruitmentController.UpdateCandidate(null) as ActionResult;
            Assert.Equal((int)System.Net.HttpStatusCode.BadRequest, ((BadRequestResult)result).StatusCode);
        }

        [Fact]
        public async Task DeleteCandidate_ReturnsTrue ()
        {
            _serviceMock.Setup(m => m.DeleteCandidate(It.IsAny<int>())).Returns(Task.FromResult(1));
            var result = await recruitmentController.DeleteCandidate(1) as ActionResult;
            Assert.Equal((int)System.Net.HttpStatusCode.OK, ((ObjectResult)result).StatusCode);
        }

        [Fact]
        public async Task DeleteCandidate_ReturnsFalse()
        {
            _serviceMock.Setup(m => m.DeleteCandidate(It.IsAny<int>())).Returns(Task.FromResult(1));
            var result = await recruitmentController.DeleteCandidate(0) as ActionResult;
            Assert.Equal((int)System.Net.HttpStatusCode.BadRequest, ((BadRequestResult)result).StatusCode);
        }
    }
}
