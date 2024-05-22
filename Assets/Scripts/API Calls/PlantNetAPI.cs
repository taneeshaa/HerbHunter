using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using TMPro;

public class PlantNetAPI : MonoBehaviour
{
    // Your API Key here
    public string apiKey;
    private string project = "all"; // Try specific floras: "weurope", "canada"…
    private string apiEndpoint;

    public TakePhotos takePhotos;
    public TextMeshProUGUI responseCode;
    public TextMeshProUGUI plantText;
    // Paths to your images
    private string imagePath1 = "Assets/Images/image_1.jpeg";
    private string imagePath2 = "Assets/Images/image_2.jpeg";

    void Start()
    {
        apiEndpoint = $"https://my-api.plantnet.org/v2/identify/{project}?api-key={apiKey}";
        
    }

    public void AnalysePhoto()
    {
        StartCoroutine(IdentifyPlant());
    }

    IEnumerator IdentifyPlant()
    {
        // Load image bytes
        //byte[] imageBytes1 = File.ReadAllBytes(imagePath1);
        //byte[] imageBytes2 = File.ReadAllBytes(imagePath2);

        byte[] imageBytes1 = File.ReadAllBytes(takePhotos.filePath);

        // Create a WWWForm and add the images and other data
        WWWForm form = new WWWForm();
        //form.AddBinaryData("images", imageBytes1, "image_1.jpeg", "image/jpeg");
        //form.AddBinaryData("images", imageBytes2, "image_2.jpeg", "image/jpeg");

        form.AddBinaryData("images", imageBytes1, takePhotos.fileName, "image/png");
        

        //form.AddField("organs", "flower");
        form.AddField("organs", "leaf");

        // Create UnityWebRequest
        using (UnityWebRequest www = UnityWebRequest.Post(apiEndpoint, form))
        {
            // Send the request and wait for a response
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                // Get the response
                string jsonResult = www.downloadHandler.text;
                responseCode.text = "Response Code: " + www.responseCode;
                //Debug.Log("Response: " + jsonResult);

                // Parse and display the JSON result
                // You can use JsonUtility or a third-party library like Newtonsoft.Json for parsing
                // Here is an example of simple parsing using Unity's JsonUtility
                PlantNetResponse response = JsonUtility.FromJson<PlantNetResponse>(jsonResult);
                Debug.Log("Plant Identifications:");
                plantText.text = response.results[0].species.scientificNameWithoutAuthor;
                foreach (var result in response.results)
                {
                    //Debug.Log("Species: " + result.species.scientificNameWithoutAuthor);
                    //Debug.Log("Score: " + result.score);
                }
            }
        }
    }
}

// Define the classes for JSON parsing
[System.Serializable]
public class PlantNetResponse
{
    public PlantNetResult[] results;
}

[System.Serializable]
public class PlantNetResult
{
    public PlantNetSpecies species;
    public float score;
}

[System.Serializable]
public class PlantNetSpecies
{
    public string scientificNameWithoutAuthor;
}

