namespace Interfaces
{
    public interface IGrabbable
    {
        public RecyclingObjectsType ObjectType();

        public void HideObject();
    }


    public interface IHoldRecyclingItem
        {
        public RecyclingObjectsType ItemType();

        public void RemoveObjectFromHand();
        }
}
