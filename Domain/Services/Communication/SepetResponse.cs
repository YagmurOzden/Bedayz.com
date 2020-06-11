using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;

namespace bedayzAPI.Domain.Services.Communication
{
    public class SepetResponse : BaseResponse
    {

        public Sepet Sepet { get; private set; }

        private SepetResponse(bool success, string message, Sepet sepet) : base(success, message)
        {
            Sepet = sepet;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="sepet">Saved sepet.</param>
        /// <returns>Response.</returns>
        public SepetResponse(Sepet sepet) : this(true, string.Empty, sepet)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SepetResponse(string message) : this(false, message, null)
        { }

    }
}
