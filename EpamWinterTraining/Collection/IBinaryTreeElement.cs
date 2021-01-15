namespace EpamWinterTraining.Collection
{
    public interface IBinaryTreeElement<T> where T : class
    {
        /// <summary>
        /// Link to the left child.
        /// </summary>
        T Left { get; set; }
        /// <summary>
        /// Link to the right child.
        /// </summary>
        T Right { get; set; }
    }
}
