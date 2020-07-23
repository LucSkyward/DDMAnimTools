# DDMAnimTools<br/>
Unity project helps convert FBX animations into DDM(Dance Dance Maker!) Animations<br/><br/>
1.Install Unity 2018.4.X<br/>
2.Open this project in Unity 2018.4.X<br/>
3.Copy the Fbx files to "Assets/FbxFiles" sub folder,for example,copy fbx to "Action" sub folder:<br/>
![](Readme/readme01.png)<br/>
4.Make sure animation type is "Humanroid"<br/>
![](Readme/readme02.png)<br/>
5.Press Menu "DDMAnimTools/FbxToMecanim",to convert FBX to unity Mecanims:<br/>
![](Readme/readme03.png)<br/>
6.Now you have mecanims in "Mecanim" sub folder:<br/>
![](Readme/readme05.png)<br/>
7.Press Menu "DDMAnimTools/MecanimToDDMAnim" to convert unity Mecanims to DDM animations:<br/>
![](Readme/readme04.png)<br/>
8.After a while you should see this under "StreamAssets" folder:<br/>
![](Readme/readme06.png)<br/>
9.That is the anim files can be used in DDM,you can copy them to sdcard for example:<br/>
adb push *.anim /sdcard/<br/>
then load anim use DDM animation file dialog.
