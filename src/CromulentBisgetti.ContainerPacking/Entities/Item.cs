using System.Runtime.Serialization;

namespace CromulentBisgetti.ContainerPacking.Entities
{
    /// <summary>
    /// An item to be packed. Also used to hold post-packing details for the item.
    /// </summary>
    [DataContract]
    public class Item
    {
        #region Private Variables

        private System.Decimal volume;

        #endregion Private Variables

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="id">The item ID.</param>
        /// <param name="dim1">The length of one of the three item dimensions.</param>
        /// <param name="dim2">The length of another of the three item dimensions.</param>
        /// <param name="dim3">The length of the other of the three item dimensions.</param>
        /// <param name="itemQuantity">The item quantity.</param>
        public Item(System.Int32 id, System.Decimal dim1, System.Decimal dim2, System.Decimal dim3, System.Int32 quantity)
        {
            ID = id;
            Dim1 = dim1;
            Dim2 = dim2;
            Dim3 = dim3;
            volume = dim1 * dim2 * dim3;
            Quantity = quantity;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the item ID.
        /// </summary>
        /// <value>
        /// The item ID.
        /// </value>
        [DataMember]
        public System.Int32 ID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this item has already been packed.
        /// </summary>
        /// <value>
        ///   True if the item has already been packed; otherwise, false.
        /// </value>
        [DataMember]
        public System.Boolean IsPacked { get; set; }

        /// <summary>
        /// Gets or sets the length of one of the item dimensions.
        /// </summary>
        /// <value>
        /// The first item dimension.
        /// </value>
        [DataMember]
        public System.Decimal Dim1 { get; set; }

        /// <summary>
        /// Gets or sets the length another of the item dimensions.
        /// </summary>
        /// <value>
        /// The second item dimension.
        /// </value>
        [DataMember]
        public System.Decimal Dim2 { get; set; }

        /// <summary>
        /// Gets or sets the third of the item dimensions.
        /// </summary>
        /// <value>
        /// The third item dimension.
        /// </value>
        [DataMember]
        public System.Decimal Dim3 { get; set; }

        /// <summary>
        /// Gets or sets the x coordinate of the location of the packed item within the container.
        /// </summary>
        /// <value>
        /// The x coordinate of the location of the packed item within the container.
        /// </value>
        [DataMember]
        public System.Decimal CoordX { get; set; }

        /// <summary>
        /// Gets or sets the y coordinate of the location of the packed item within the container.
        /// </summary>
        /// <value>
        /// The y coordinate of the location of the packed item within the container.
        /// </value>
        [DataMember]
        public System.Decimal CoordY { get; set; }

        /// <summary>
        /// Gets or sets the z coordinate of the location of the packed item within the container.
        /// </summary>
        /// <value>
        /// The z coordinate of the location of the packed item within the container.
        /// </value>
        [DataMember]
        public System.Decimal CoordZ { get; set; }

        /// <summary>
        /// Gets or sets the item quantity.
        /// </summary>
        /// <value>
        /// The item quantity.
        /// </value>
        public System.Int32 Quantity { get; set; }

        /// <summary>
        /// Gets or sets the x dimension of the orientation of the item as it has been packed.
        /// </summary>
        /// <value>
        /// The x dimension of the orientation of the item as it has been packed.
        /// </value>
        [DataMember]
        public System.Decimal PackDimX { get; set; }

        /// <summary>
        /// Gets or sets the y dimension of the orientation of the item as it has been packed.
        /// </summary>
        /// <value>
        /// The y dimension of the orientation of the item as it has been packed.
        /// </value>
        [DataMember]
        public System.Decimal PackDimY { get; set; }

        /// <summary>
        /// Gets or sets the z dimension of the orientation of the item as it has been packed.
        /// </summary>
        /// <value>
        /// The z dimension of the orientation of the item as it has been packed.
        /// </value>
        [DataMember]
        public System.Decimal PackDimZ { get; set; }

        /// <summary>
        /// Gets the item volume.
        /// </summary>
        /// <value>
        /// The item volume.
        /// </value>
        [DataMember]
        public System.Decimal Volume
        {
            get
            {
                return volume;
            }
        }

        #endregion Public Properties
    }
}
