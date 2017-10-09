using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerInventory))]
public class PlayerInventoryDisplay : MonoBehaviour 
{
	const int NUM_INVENTORY_SLOTS = 10;

	// array of references to slot panel GameObjects
	private PickupUI[] slots = new PickupUI[NUM_INVENTORY_SLOTS];

	public GameObject panelSlotGrid;
	public GameObject starSlotPrefab;

	void Awake()
	{
		float width = 50 + (NUM_INVENTORY_SLOTS * 50);

		panelSlotGrid.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);

		for(int i=0; i < NUM_INVENTORY_SLOTS; i++){
			GameObject starSlotGO = (GameObject)
				Instantiate(starSlotPrefab);
			starSlotGO.transform.SetParent(panelSlotGrid.transform);
			starSlotGO.transform.localScale = new Vector3(1,1,1);
			slots[i] = starSlotGO.GetComponent<PickupUI>();
		}
	}

	
	public void OnChangeStarTotal(int starTotal)
	{
		for(int i = 0; i < NUM_INVENTORY_SLOTS; i++){
			PickupUI slot = slots[i];
			if(i < starTotal)
				slot.DisplayColorIcon();
			else
				slot.DisplayGreyIcon();
		}
	}
}
