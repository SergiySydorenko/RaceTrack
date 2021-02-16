using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RaceTrack.Controllers;
using RaceTrack.Entities;
using RaceTrack.Models;
using RaceTrack.Repositories;

namespace RaceTrack.UnitTests
{
    [TestClass]
    public class AddVehicleOnTrackControllerTests
    {   
        private static Mock<IRepository> GetNumberOfVehicles(int num)
        {
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetVehiclesOnTrackCount()).Returns(num);
            return mock;
        }

        [TestMethod]
        public void ErrorWhen5VehiclesOnTrack()
        {
            // Arrange
            Mock<IRepository> mock = GetNumberOfVehicles(5);

            var controller = new AddVehicleOnTrackController(mock.Object);

            // Act
            var result = controller.Add("car").Value;

            // Assert           
            Assert.AreEqual(result, "nok");
        }

        [TestMethod]
        public void ErrorWhenWrongVehicleName()
        {
            // Arrange
            Mock<IRepository> mock = GetNumberOfVehicles(4);

            var controller = new AddVehicleOnTrackController(mock.Object);

            // Act
            var result = controller.Add("false").Value;

            // Assert           
            Assert.AreEqual(result, "error");
        }

        [TestMethod]
        public void SuccessWhen4VehiclesOnTrack()
        {
            // Arrange
            Mock<IRepository> mock = GetNumberOfVehicles(4);
            mock.Setup(repo => repo.GetVehicle(VehicleEnum.Car)).Returns(new Vehicle() { Name = "car" });

            var controller = new AddVehicleOnTrackController(mock.Object);

            // Act
            var result = controller.Add("car").Value;

            // Assert           
            Assert.AreEqual(result, "ok");
        }

    }
}
