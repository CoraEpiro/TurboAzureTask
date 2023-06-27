using Bogus;
using SixLabors.ImageSharp.Formats.Jpeg;
using TurboAzureTask.Models;
using Azure.Storage.Blobs;
using System.Drawing;

namespace TurboAzureTask.Services;
public static class CarSeed
{
    static private async Task<string> GenerateCarImage()
    {
        using (Image<Rgba32> image = new Image<Rgba32>(800, 600))
        {
            // Apply image processing operations
            
            // Convert the image to a byte array
            using (var ms = new MemoryStream())
            {
                image.Save(ms, new JpegEncoder());
                var imageBytes = ms.ToArray();

                // Connect to Azure Blob Storage
                var connectionString = "your-storage-connection-string";
                var containerName = "your-container-name";
                var blobName = "car-image.jpg";
                var blobClient = new BlobClient(connectionString, containerName, blobName);

                // Upload the image to Azure Blob Storage
                using (var stream = new MemoryStream(imageBytes))
                {
                    await blobClient.UploadAsync(stream, overwrite: true);
                }

                // Return the URL of the saved image
                return blobClient.Uri.AbsoluteUri;
            }
        }
    }
    static public IEnumerable<Car> GenerateCar(int numberOfCars)
    {
        var cars = new List<Car>();
        var faker = new Faker("en");

        for (int i = 0; i < numberOfCars; i++)
        {
            var car = new Car();
            car.Id = Guid.NewGuid().ToString();
            car.CarManufacturer = faker.Vehicle.Manufacturer();
            car.CarModel = faker.Vehicle.Model();
            car.CarYear = faker.Date.Past().Year;
            car.CarPrice = faker.Random.Number(10000, 100000);
            car.CarImage = faker.Image.PicsumUrl();
            car.CarDescription = faker.Lorem.Sentence();
            car.CarCity = faker.Address.City();
            car.CarColor = faker.Commerce.Color();
            car.CarKilometer = faker.Random.Number(10000, 100000);
            car.CarDate = faker.Date.Past();
            car.CarStatus = faker.Random.Bool().ToString();
            car.CarName = car.CarManufacturer + " " + car.CarModel;
            cars.Add(car);
        }

        return cars;
    }
}
