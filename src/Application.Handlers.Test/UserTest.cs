using Application.Handlers;
using Application.Notifications;
using Application.Pipelines;
using Domain.Interfaces.Repository;
using Domain.Models.Commands.Requests;
using Domain.Models.Commands.Responses;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Handlers.Test
{
    public class UserTest
    {
        private Mock<IMediator> _mockMediator;
        private UserCreateCommand _userCreateCommandDefaultMock;

        public UserTest()
        {
            _mockMediator = new Mock<IMediator>();
            _mockMediator.Setup(x => x.Publish(new LogNotification(It.IsAny<string>()), It.IsAny<CancellationToken>()));

            _userCreateCommandDefaultMock = new UserCreateCommand(
                typeDocument: 1,
                documentNumber: "123456789",
                initialName: "Everton",
                middleName: "José",
                lastName: "Benedicto",
                dateBirth: new DateTime(1987, 05, 30),
                email: "analista.everton@gmail.com",
                userEntry: "ebenedicto");
        }

        [Fact]
        public async Task ValidateCreateRequestSuccess()
        {
            var handlerDelegate = new Mock<RequestHandlerDelegate<UserResponse>>();

            handlerDelegate.Setup(x => x.Invoke()).ReturnsAsync(new UserResponse());

            var handler = new ValidateCommandHandler<UserCreateCommand, UserResponse>();
            var result = await handler.Handle(_userCreateCommandDefaultMock, CancellationToken.None, handlerDelegate.Object);

            Assert.False(result.HasValidations);
        }

        [Fact]
        public async Task ValidateCreateRequestTypeDocumentNoValidade()
        {

            var request = new UserCreateCommand(
                typeDocument: 0,
                documentNumber: "123456789",
                initialName: "Everton",
                middleName: "José",
                lastName: "Benedicto",
                dateBirth: new DateTime(1987, 05, 30),
                email: "analista.everton@gmail.com",
                userEntry: "ebenedicto");
            var handlerDelegate = new Mock<RequestHandlerDelegate<UserResponse>>();

            handlerDelegate.Setup(x => x.Invoke()).ReturnsAsync(new UserResponse());

            var handler = new ValidateCommandHandler<UserCreateCommand, UserResponse>();
            var result = await handler.Handle(request, CancellationToken.None, handlerDelegate.Object);

            Assert.True(result.HasValidations);
        }

        [Fact]
        public async Task ExecuteUserCreateHandler()
        {
            var handlerDelegate = new Mock<RequestHandlerDelegate<UserResponse>>();
            var mockpaymentRepository = new Mock<IUserRepository>();

            handlerDelegate.Setup(x => x.Invoke()).ReturnsAsync(new UserResponse());

            var handler = new UserCreateHandler(_mockMediator.Object, mockpaymentRepository.Object);
            var result = await handler.Handle(_userCreateCommandDefaultMock, CancellationToken.None);

            Assert.True(result.Success);
        }

        [Fact]
        public async Task ExecuteUserUpdateHandler()
        {
            var request = new UserUpdateCommand(
                userId: 1,
                typeDocument: 1,
                documentNumber: "123456789",
                initialName: "Everton",
                middleName: "José",
                lastName: "Benedicto",
                dateBirth: new DateTime(1987, 05, 30),
                email: "analista.everton@gmail.com");
            var handlerDelegate = new Mock<RequestHandlerDelegate<UserResponse>>();
            var mockpaymentRepository = new Mock<IUserRepository>();

            handlerDelegate.Setup(x => x.Invoke()).ReturnsAsync(new UserResponse());

            var handler = new UserUpdateHandler(_mockMediator.Object, mockpaymentRepository.Object);
            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result.Success);
        }
    }
}