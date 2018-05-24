using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Entities;
using CromulentBisgetti.DemoApp.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CromulentBisgetti.DemoApp.Controllers
{
    using System.Linq;

    /// <summary>
    /// The API controller for container packing.
    /// </summary>
    public class ContainerPackingController : ApiController
    {
        /// <summary>
        /// Posts the specified packing request.
        /// </summary>
        /// <param name="request">The packing request.</param>
        /// <returns>A container packing result with lists of packed and unpacked items.</returns>
        [HttpPost]
        public List<ContainerPackingResult> Post([FromBody]ContainerPackingRequest request)
        {
            return PackingService.Pack(request.Containers, request.ItemsToPack.OrderByDescending(i => i.Volume).ToList(), request.AlgorithmTypeIDs);
        }
    }
}