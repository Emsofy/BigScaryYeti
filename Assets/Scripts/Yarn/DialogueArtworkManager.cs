using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueArtworkManager : MonoBehaviour
{

    private static DialogueArtworkManager instance;

    [Header("UI Reference")]
    public Image uiImageDisplay;

    [System.Serializable]
    public struct ArtworkData
    {
        public string imageName;
        public Sprite imageSprite;
    }

    [Header("Image Library")]
    public ArtworkData[] artworkLibrary;

    private void Awake()
    {

        instance = this;
    }


    [YarnCommand("show_image")]
    public static void SwapDialogueImage(string targetName)
    {
        if (instance == null)
        {
            Debug.LogError("DialogueArtworkManager is missing from the active scene!");
            return;
        }

        foreach (var artwork in instance.artworkLibrary)
        {
            if (artwork.imageName == targetName)
            {
                if (!instance.uiImageDisplay.gameObject.activeSelf)
                {
                    instance.uiImageDisplay.gameObject.SetActive(true);
                }

                instance.uiImageDisplay.sprite = artwork.imageSprite;
                return;
            }
        }

        Debug.LogWarning($"Artwork with name '{targetName}' was not found in the library.");
    }
}