using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bedayzAPI.Domain.Models;

namespace bedayzAPI.Domain.Services.Communication
{
    public class SiparisResponse : BaseResponse
    {
        public Siparis Siparis { get; private set; }

        private SiparisResponse(bool success, string message, Siparis siparis) : base(success, message)
        {
            Siparis = siparis;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="siparis">Saved category.</param>
        /// <returns>Response.</returns>
        public SiparisResponse(Siparis siparis) : this(true, string.Empty, siparis)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SiparisResponse(string message) : this(false, message, null)
        { }


    }
}
