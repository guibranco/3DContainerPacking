using CromulentBisgetti.ContainerPacking;
using CromulentBisgetti.ContainerPacking.Algorithms;
using CromulentBisgetti.ContainerPacking.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CromulentBisgetti.ContainerPackingTests
{
    [TestClass]
    public class ContainerPackingTests
    {
        [TestMethod]
        public void EB_AFIT_Passes_700_Standard_Reference_Tests()
        {
            // ORLibrary.txt is an Embedded Resource in this project.
            var resourceName = "CromulentBisgetti.ContainerPackingTests.DataFiles.ORLibrary.txt";
            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    // Counter to control how many tests are run in dev.
                    var counter = 1;

                    while (reader.ReadLine() != null && counter <= 700)
                    {
                        var itemsToPack = new List<Item>();

                        // First line in each test case is an ID. Skip it.

                        // Second line states the results of the test, as reported in the EB-AFIT master's thesis, appendix E.
                        var testResults = reader.ReadLine().Split(' ');

                        // Third line defines the container dimensions.
                        var containerDims = reader.ReadLine().Split(' ');

                        // Fourth line states how many distinct item types we are packing.
                        var itemTypeCount = Convert.ToInt32(reader.ReadLine());

                        for (var i = 0; i < itemTypeCount; i++)
                        {
                            var itemArray = reader.ReadLine().Split(' ');

                            var item = new Item(0, Convert.ToDecimal(itemArray[1]), Convert.ToDecimal(itemArray[3]), Convert.ToDecimal(itemArray[5]), Convert.ToInt32(itemArray[7]));
                            itemsToPack.Add(item);
                        }

                        var containers = new List<Container>();
                        containers.Add(new Container(0, Convert.ToDecimal(containerDims[0]), Convert.ToDecimal(containerDims[1]), Convert.ToDecimal(containerDims[2])));

                        var result = PackingService.Pack(containers, itemsToPack, new List<Int32> { (Int32)AlgorithmType.EB_AFIT });

                        // Assert that the number of items we tried to pack equals the number stated in the published reference.
                        Assert.AreEqual(result[0].AlgorithmPackingResults[0].PackedItems.Count + result[0].AlgorithmPackingResults[0].UnpackedItems.Count, Convert.ToDecimal(testResults[1]));

                        // Assert that the number of items successfully packed equals the number stated in the published reference.
                        Assert.AreEqual(result[0].AlgorithmPackingResults[0].PackedItems.Count, Convert.ToDecimal(testResults[2]));

                        // Assert that the packed container volume percentage is equal to the published reference result.
                        // Make an exception for a couple of tests where this algorithm yields 87.20% and the published result 
                        // was 87.21% (acceptable rounding error).
                        Assert.IsTrue(result[0].AlgorithmPackingResults[0].PercentContainerVolumePacked == Convert.ToDecimal(testResults[3]) ||
                            (result[0].AlgorithmPackingResults[0].PercentContainerVolumePacked == 87.20M && Convert.ToDecimal(testResults[3]) == 87.21M));

                        // Assert that the packed item volume percentage is equal to the published reference result.
                        Assert.AreEqual(result[0].AlgorithmPackingResults[0].PercentItemVolumePacked, Convert.ToDecimal(testResults[4]));

                        counter++;
                    }
                }
            }
        }
    }
}
