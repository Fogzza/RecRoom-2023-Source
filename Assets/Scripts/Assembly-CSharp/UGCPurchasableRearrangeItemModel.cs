public class UGCPurchasableRearrangeItemModel : UGCPurchasableItemModel
{
	public bool ItemCanMoveUpInCarousel()
	{
		return false;
	}

	public bool ItemCanMoveDownInCarousel()
	{
		return false;
	}

	public void MoveItemUpInCarousel()
	{
	}

	public void MoveItemDownInCarousel()
	{
	}
}
