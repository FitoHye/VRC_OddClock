////////////////////////////////////////////////////////////////
ヨドコロちゃんのポテトチップス
Yodokoro-chan's Potato chips
////////////////////////////////////////////////////////////////


Release Note:
2021/01/05	Release
2021/01/13	Added some flavours(Norishio/Chocolate/HotChilli)
2021/05/22	Updated for new Sync system(UNU)
2021/07/17	Added some flavours(Pepper/Cheese/Mentai(Spicy cod roe))
		Udon Chips integration
2021/08/17	Official support for Unity 2019
		Fixed a bug that caused to output debug log spamming.

===Description===

Thank you for downloading the Yodokoro-chan's Potato chips.
Please make sure to read the Terms of Use before using this asset.

This asset provides a model and U# script for deploy a bowl of potato chips with eating gimmick for VRChat world creators.
Of course, you can use the model only or the script only.
Credit notation is not required, but it would be nice to have it. I would be more than happy to notice it to me.


===Function===

---Yodo_PotatoChips---

This is a bowl full of potato chips.
6 of them are individual Pickups, and by grabbing and releasing them, the effects and sound effects as if you had eaten them will happens.
The eaten chips will reappear 2 seconds later at a random location/orientation in the pile of chips.

The appearance and effects are synchronized globally.

There are three types of potatoes for appearance and four types of sound effects for eating.
There are only two materials (potatoes and effects), so the rendering load is very light.


---Udon Chips integration---

Since v2.0, we support Udon Chips.
If there is a "UdonChips" object in the Scene, the price you set will be paid from your wallet when you eat chips.
If you don't have enough udon chips, you will not be able to eat chips.

You can set the price freely. By default, we have two types of Prefab: 1uc and 0uc (free).

If your world does not have Udon Chips, you will still be able to eat them freely.

More informations about Udon Chips here:
https://booth.pm/ja/items/3060394



===Install===

You must to import in the following order.

1. VRCSDK3-WORLD-2021.05.17.12.52_Public or more newer
2. UdonSharp for the SDK version you installed
3. This asset

This asset is for SDK3 only. Can not be used in the SDK2 world.

UdonSharp information and download is here: https://github.com/MerlinVR/UdonSharp/


===How to Use===

Just place Yodo_PotatoChips.prefab in your scene.

That's all.
You can place it multiply. They works indivisually.


If you want to integrate with Udon Chips, you need to place one file Assets/UdonChips/00_UdonChips/UdonChips.prefab in the Scene.
You only need one UdonChips.prefab for the whole system, so you don't need to redeploy it if it's already exists in your scene.

The price is 1uc by default.
Prefab with "Free" in its name is 0uc (free) and allows unlimited eating as before.

If you want to set it yourself, select one of the "Chips/Chips (0)-(5)" in each Prefab and click in the Udon Behaviour where Yodo_PotatoChip is set, set the Yodo_Udon Chip Price to the price you want.
Please note that you need to set this value for all 6 objects.


Here's an explanation for those who know a bit about Udon.

--------BEGIN---------
Yodo_PotatoChips detects OnDrop() of its own PickUp, and send "Eat event" for all players.
"EatEvent" will search for a wait state one in the child of the GameObject (EffectObject) specified in Yodo_EffectObjectProvider and move to the point where the "Eat event" occurs.
The EffectObject must have an AudioSource and a Particle, and will play the eating sound and effect. And then sets potato's Scale to 0 and moves to the respawn point.
By splitting the effect and the potatoes into two objects in this way, we can prevent the sound source from moving during playback, even if the positional synchronization is lagged.
Also, since the movement of the effect is local, the only object that needs Position Sync is the potato chip itself. It makes network traffic lighter!

You can increase the number of potatoes and EffectObjects by simply copying them using Ctrl+D.
The number of EffectObjects is the number of effects that can be played at the same time, so even if you increase the number of potatoes, you don't need that many unless you want to eat them all at the same time.
Well, If you want to put about 100 potatoes on a huge plate and have dozens of people devouring them all at once, then increase the number of EffectObjects to about the same number as potatoes tho.

If you change the size of the plate, you can adjust the respawn range with Yodo_spawnRandomizeRadious.
XYZ is the radius around the Parent's Position, respectively. 1 means that the object will respawn between -1 and 1 from the center.
---------END----------


===Known issue===

1.
If more than one player picks up a potato chip at the same time, 
it may appear as if potato chip has removed his hand without eaten.
This is a limitation of the synchronization speed, so I can't take care about it anymore.
If you are planning to have a lot of food-fights, you can reduce the incidence by increasing the number of potatoes.

2.
If you are holding a potato chip and try to grab it with your other hand, it will eat it.
In addition, if you keep holding it for two seconds, the potatoes will respawn, but you are still holding it from far place.
It might be a bug. Please vote this canny I wrote.
https://vrchat.canny.io/vrchat-udon-closed-alpha-bugs/p/vrcpickupisheld-and-vrcplayerapigetpickupinhand-has-inconsistented-in-ondrop


===Licenses and Terms===

This asset is provided under a VN3 license.
Please refer to the license file included in the package for the license terms.


===Contact===
twitter: @Yodokor0

生チョコ教団 contact form
https://docs.google.com/forms/d/e/1FAIpQLSe9964vA11qDYH0gjDfkSKVDUY7RyILjmN3tqYfXGWVJzMHvQ/viewform
