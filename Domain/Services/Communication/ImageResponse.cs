using bedayzAPI.Domain.Models;

namespace bedayzAPI.Domain.Services.Communication
{
    public class ImageResponse : BaseResponse
    {
        public Image Image { get; private set; }

        private ImageResponse(bool success, string message, Image image) : base(success, message)
        {
            Image = image;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="image">Saved category.</param>
        /// <returns>Response.</returns>
        public ImageResponse(Image image) : this(true, string.Empty, image)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public ImageResponse(string message) : this(false, message, null)
        { }
    }
}
