using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AvatarController : MonoBehaviour
{
    //Image
    [SerializeField] Transform AvatarSpawnLocation;
    [SerializeField] Sprite BardImage;
    [SerializeField] Sprite BarbarianImage;
    [SerializeField] Sprite WizardImage;
    [SerializeField] Sprite MonkImage;
    [SerializeField] Sprite DruidImage;
    [SerializeField] Sprite ClericImage;
    [SerializeField] Sprite RogueImage;
    [SerializeField] Sprite SorcererImage;

    private Sprite createdImage;

    //Name
    [SerializeField] TextMeshProUGUI nameText;

    public void SetupAvatar(string className)
    {
        switch(className)
        {
            case "Bard":
                createdImage = Instantiate(BardImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Barbarian":
                createdImage = Instantiate(BarbarianImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Wizard":
                createdImage = Instantiate(WizardImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Sorcerer":
                createdImage = Instantiate(SorcererImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Monk":
                createdImage = Instantiate(MonkImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Druid":
                createdImage = Instantiate(MonkImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Cleric":
                createdImage = Instantiate(MonkImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
            case "Rogue":
                createdImage = Instantiate(MonkImage, AvatarSpawnLocation);
                nameText.text = className;
                break;
        }
    }
}
