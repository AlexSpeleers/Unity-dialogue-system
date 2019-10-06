Got 3 Scriptable objects:
NPC - can contain name and position (was an idea to instatiate an array of npc dynamicaly in different
 spots and with different names/prefabs).
Dialogue - struct array with dialogue text and reference to npc.
Choice - struct array with choice text and next SO dialogue to use.

Got 2 scripts on player:
standart unity controller.
interaction - that checks wether player is near npc. Npc got large collider on his head.

Got 3 ui scripts:
DialogueDataHolder - is a component of NPC's head - used to contain SO info.
DialogueDisplay - that one script that extract  data from SO and send it into ui fields.
choice controller - isn't implemented in the scene yet.
To progress dialog - press Q.