namespace CromulentBisgetti.ContainerPacking.Entities
{
    /// <summary>
    /// The container to pack items into.
    /// </summary>
    public class Container
    {
        #region Private Variables

        private System.Decimal volume;

        #endregion Private Variables

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Container class.
        /// </summary>
        /// <param name="id">The container ID.</param>
        /// <param name="length">The container length.</param>
        /// <param name="width">The container width.</param>
        /// <param name="height">The container height.</param>
        public Container(System.Int32 id, System.Decimal length, System.Decimal width, System.Decimal height)
        {
            ID = id;
            Length = length;
            Width = width;
            Height = height;
            Volume = length * width * height;
        }

        #endregion Constructors

        #region Public Properties
        /// <summary>
        /// Gets or sets the container ID.
        /// </summary>
        /// <value>
        /// The container ID.
        /// </value>
        public System.Int32 ID { get; set; }

        /// <summary>
        /// Gets or sets the container length.
        /// </summary>
        /// <value>
        /// The container length.
        /// </value>
        public System.Decimal Length { get; set; }

        /// <summary>
        /// Gets or sets the container width.
        /// </summary>
        /// <value>
        /// The container width.
        /// </value>
        public System.Decimal Width { get; set; }

        /// <summary>
        /// Gets or sets the container height.
        /// </summary>
        /// <value>
        /// The container height.
        /// </value>
        public System.Decimal Height { get; set; }

        /// <summary>
        /// Gets or sets the volume of the container.
        /// </summary>
        /// <value>
        /// The volume of the container.
        /// </value>
        public System.Decimal Volume
        {
            get
            {
                return volume;
            }
            set
            {
                volume = value;
            }
        }

        #endregion Public Properties
    }
}
