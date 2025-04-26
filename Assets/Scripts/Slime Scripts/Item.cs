using UnityEngine;
class Item{

    public int itemID;
    public string itemName = "Item";
    public string itemDescription = "This is an item";
    public string itemCatagory = "Dropped";

    public Item(int iD=1){
        itemID = iD;

        switch(itemID){
            case 1:
                itemName = "Spring water";
                itemCatagory = "Dropped";
                break;
            case 2:
                itemName = "Cooled Magma";
                itemCatagory = "Dropped";
                break;
            case 3:
                itemName = "Stone shards";
                itemCatagory = "Dropped";
                break;
            case 4:
                itemName = "Grass Clump";
                itemCatagory = "Dropped";
                break;
            case 5:
                itemName = "Ice Cube";
                itemCatagory = "Dropped";
                break;
            case 6:
                itemName = "Cloud Lump";
                itemCatagory = "Dropped";
                break;
            case 7:
                itemName = "lightning In A Bottle";
                itemCatagory = "Dropped";
                break;
            case 8:
                itemName = "Fresh Mudd";
                itemCatagory = "Dropped";
                break;
            case 9:
                itemName = "Snow Ball";
                itemCatagory = "Dropped";
                break;
            case 10:
                itemName = "Ash";
                itemCatagory = "Dropped";
                break;
            default:
                itemName = "Spring water";
                itemCatagory = "Dropped";
                break;
        }

    }

}