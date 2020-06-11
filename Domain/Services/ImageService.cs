using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;
using bedayzAPI.Domain.Services;
using bedayzAPI.Domain.Repositories;
using bedayzAPI.Persistence.Repositories;
using bedayzAPI.Domain.Services.Communication;

namespace bedayzAPI.Domain.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ImageService(IImageRepository imageRepository, IUnitOfWork unitOfWork)
        {
            _imageRepository = imageRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Image>> ListAsync()
        {
            return await _imageRepository.ListAsync();
        }
        public async Task<ImageResponse> SaveAsync(Image image)
        {
            try
            {
                await _imageRepository.AddAsync(image);
                await _unitOfWork.CompleteAsync();

                return new ImageResponse(image);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ImageResponse($"An error occurred when saving the image: {ex.Message}");
            }
        }
        public async Task<ImageResponse> UpdateAsync(int id, Image image)
        {
            var existingImage = await _imageRepository.FindByIdAsync(id);

            if (existingImage == null)
                return new ImageResponse("Image not found.");

            existingImage.Name = image.Name;

            try
            {
                _imageRepository.Update(existingImage);
                await _unitOfWork.CompleteAsync();

                return new ImageResponse(existingImage);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ImageResponse($"An error occurred when updating the image: {ex.Message}");
            }
        }
        public async Task<ImageResponse> DeleteAsync(int id)
        {
            var existingImage = await _imageRepository.FindByIdAsync(id);

            if (existingImage == null)
                return new ImageResponse("Image not found.");

            try
            {
                _imageRepository.Remove(existingImage);
                await _unitOfWork.CompleteAsync();

                return new ImageResponse(existingImage);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ImageResponse($"An error occurred when deleting the image: {ex.Message}");
            }
        }
    }
}

