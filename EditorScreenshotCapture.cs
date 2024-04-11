using UnityEngine;
using UnityEditor;
using System.IO;

public class EditorScreenshotCapture : EditorWindow
{
    private int width = 256;
    private int height = 256;

    [MenuItem("Tools/Screenshot Window")]
    static void Init()
    {
        EditorScreenshotCapture window = (EditorScreenshotCapture)EditorWindow.GetWindow(typeof(EditorScreenshotCapture));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Label("Select Image Size", EditorStyles.boldLabel);
        width = EditorGUILayout.IntField("Width:", width);
        height = EditorGUILayout.IntField("Height:", height);

        if (GUILayout.Button("Use Screen Size"))
        {
            SetToScreenSize();
        }

        if (GUILayout.Button("Take Screenshot"))
        {
            TakeScreenshot();
        }
    }

    void SetToScreenSize()
    {
        width = Screen.currentResolution.width;
        height = Screen.currentResolution.height;
    }

    void TakeScreenshot()
    {
        var cam = Camera.main;
        if (cam == null)
        {
            Debug.LogError("Main camera not found.");
            return;
        }
        RenderTexture renderTexture = new RenderTexture(width, height, 24);
        Texture2D screenshotTexture = new Texture2D(width, height, TextureFormat.RGB24, false);
        cam.targetTexture = renderTexture;
        cam.Render();


        RenderTexture.active = renderTexture;
        screenshotTexture.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        screenshotTexture.Apply();

        cam.targetTexture = null;
        RenderTexture.active = null;
        DestroyImmediate(renderTexture);

        byte[] bytes = screenshotTexture.EncodeToPNG();
        DestroyImmediate(screenshotTexture);

        string defaultFileName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";
        string directoryPath = Application.dataPath + "/Screenshots";

        // Check if the screenshots directory exists, if not, create it
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        string filePath = directoryPath + "/" + defaultFileName;

        File.WriteAllBytes(filePath, bytes);
        AssetDatabase.Refresh();
        Debug.Log("Screenshot saved to: " + filePath);
    }
}
