# Shaders

## Unity Version:
- 2019.2.15f1

## Requirements:
- Download in the Asset Store : Standard Assets (for Unity 2017.3)
- Download in the Asset Store : Low Poly Forest Pack

## Config:
- On your ```Player Object``` > add the tag "Player" > Create an empty object "Target" > Put the ```Main Camera Object``` on the object "Target"
- On your ```Player Object``` > add the script "CharactControlThirdP.cs" > add a Rigidbody
- On your ```Main Camera Object``` > add the script "CamControlThirdP.cs" & "SphericalMaskScript.cs"
- On your Materials > add the Shader ```MaskColorToonShader_1.shader```

## Camera:
- Move your mouse to control the direction on the object player
- Keep right click pressed to switch to the free camera
- Tap right click to reset the camera position

## Controls:
- ```Z``` to move forward
- ```Q``` to move on the left
- ```S``` to move backward
- ```Q``` to move on the right
- ```SPACE``` to jump

## About:
I made this Shader script to train and play with shaders, the shader is working with all the materials where it is applied.
Basicaly the materials will appears with shades of gray until it is not on the area of the Raycast of the script "SphericalMaskScript" applied on the Camera.
You can play with the settings of the Raycast (Radius, Softness etc...) on the pannel of the script after applied it.

Enjoy ! :)

