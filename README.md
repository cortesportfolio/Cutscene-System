To see it in action, download Unity Editor 2021.3.1f1 or higher. 

Open up the sample scene > Select play 
Select Cutscene Test in the Hierarchy and Press the "Test Me" button in the inspector.

This system was made as a commission for the game Of Carrots And Courage as a way to create a system to run Cutscenes. 

Blocks are easily creatible, editable and addable to the cutscene scripts. They rely on polymorphism for all of this with serializable code behind it to run custom drawers.

NOTE: On instance bug. Due to how arrays work, hitting the plus on the Cutscene Block array will create a duplicate of the last selected item. 
Fix: Switch the newly added block to another type to run the OnValidate method and fix it to a unique instance.
