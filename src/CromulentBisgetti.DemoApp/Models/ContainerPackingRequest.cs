﻿using CromulentBisgetti.ContainerPacking.Entities;
using System.Collections.Generic;

namespace CromulentBisgetti.DemoApp.Models
{
    public class ContainerPackingRequest
    {
        public List<Container> Containers { get; set; }

        public List<Item> ItemsToPack { get; set; }

        public List<System.Int32> AlgorithmTypeIDs { get; set; }
    }
}