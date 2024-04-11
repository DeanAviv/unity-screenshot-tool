# Screenshot Window Tool for Unity Editor

**Description:**
A Unity Editor Tool that allows to easily capture screenshots within the Unity Editor environment. With this tool, you can capture screenshots of custom sizes or screen resolution.

**Features:**
- Capture screenshots of custom sizes or screen resolution.
- User-friendly interface within Unity Editor.

**Usage:**
1. **Installation:**
   - Download the `EditorScreenshotCapture.cs` script.
   - Place the script in your Unity project's `Editor` folder.

2. **Accessing the Tool:**
   - Open Unity Editor.
   - Go to `Window` > `Tools` > `Screenshot Window`.

3. **Using the Tool:**
   - Set the desired image size by specifying width and height.
   - Click "Use Screen Size" to set the image size to the current screen resolution. 
   - Click "Take Screenshot" to capture the screenshot.

4. **Using Camera Clear Flags:**
   - Clear flags control what is rendered in the background of the scene.
   - To set clear flags, navigate to the scene view.
   - In the camera settings, you can choose from different clear flags:
     - `Skybox`: Render the skybox as the background.
     - `Solid Color`: Render a solid color as the background.
     - `Depth Only`: Render only the depth buffer, resulting in no visible background.
   - To create screenshots with no backgrounds, use the `Depth Only` flag.
   - To keep the color background, use the `Skybox` or `Solid Color` flag.

**Contributing:**
- Feel free to contribute to the project by submitting bug reports, feature requests, or pull requests.

**License:**
This project is licensed under the MIT License. See the LICENSE file for details.

**Acknowledgements:**
- Special thanks to [Unity Technologies](https://unity.com/) for providing the Unity Editor platform.

**Contact:**
For any inquiries or feedback, please contact [Dean Aviv](deanaviv5@gmail.com).
