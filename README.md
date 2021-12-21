# unity-localization
Localization for Unity

# install
Use this repository directly in Unity.

### Dependencies
* https://github.com/KleinerHacker/unity-extension
* https://github.com/KleinerHacker/unity-editor-ex
* https://github.com/KleinerHacker/unity-asset-loader

### Open UPM
URL: https://package.openupm.com

Scope: org.pcsoft

# usage

### Keys
To setup your keys change to project settings and search for `Localization` tab. Here you find setup for fallback language, supported languages and three tables:
* Text values - For texts only
* Sprite values - For sprites like sprite renderer oder UI images
* Material values - For materials used in renderers

Use a '/' to create a sub menu in case of choising a key. See below.

![demo](https://github.com/KleinerHacker/unity-localization/blob/7b15cdf4fbfd4a92ce57d0804c26077da62cf606/Doc/demo.png)

### Components
* For Texts
  * Localized Text
  * Localized Text Mesh
* For Sprites
  * Localized Sprite (for Sprite Renderer)
  * Localized Image (for UI Image)
* For Materials
  * Localized Renderer (for Renderer)

Each key dropdown of this components shows only the fit keys. Values will update at editor time initial. In game it will update with first frame (method `Start`).

### References
For usage in custom components or assets there are reference types with implicit operators:
* `LocalizedTextRef`
* `LocalizedSpriteRef`
* `LocalizedMaterialRef`

For this types an editor is implemented.

### Change Language
* At runtime - Use the class `UnityLocale` to access current settings and change language via `CurrentLanguage`.
* At editor time - Use `Language` menu in unity to change in scene texts to preview other languages.
