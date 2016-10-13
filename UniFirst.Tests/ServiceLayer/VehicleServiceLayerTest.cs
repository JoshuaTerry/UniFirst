using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniFirst.Models;
using Moq;
using UniFirst.Services;

namespace UniFirst.Tests.ServiceLayer
{
    [TestClass]
    public class VehicleServiceLayerTest
    {
        private Mock<IVehicleRepository> mockRepo;

        [TestInitialize]
        public void Setup()
        {
            // Setup a couple of mock methods as an example
            mockRepo = new Mock<IVehicleRepository>();
            mockRepo.Setup(m => m.GetDistributionCenter(It.IsAny<int>()))
                .Returns(new DistributionCenter() { Id = 123, Name = "Distro1" });

            mockRepo.Setup(m => m.SaveVehicle(It.IsAny<IVehicle>())).Returns(true);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void VehicleVINInvalidLength()
        {
            var v = new Van() { VIN = "23ABC456EFG789HIJ123456" };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void VehicleVINInsufficientAlpha()
        {
            var v = new Van() { VIN = "123ABC456EFG789111123456" };
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void VehicleVINInvalidEndCharacters()
        {
            var v = new Van() { VIN = "123ABC456EFG789HIJ12345A" };
        }

        [TestMethod]
        public void VehicleVINIsValid()
        {
            var v = new Van() { VIN = "123ABC456EFG789HIJ123456" };
            Assert.IsInstanceOfType(v, typeof(Van));
        }



        [TestMethod]
        [ExpectedException(typeof(InvalidDataException))]
        public void InvalidDistroTransferNoLocationId()
        {
            var v = new Semi();

            // Inject the mock repo
            var service = new VehicleService(mockRepo.Object);
            var result = service.DistributionTransfer(new DistributionCenter() { Id = 123 }, v);
        }
    }
}
