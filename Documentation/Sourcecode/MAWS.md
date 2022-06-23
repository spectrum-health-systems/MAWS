<!-- b220621.115657 -->

<div align="center">

  <h1> 

    MAWS SOURCODE DOCUMENTATION
  </h1>

</div>

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS**

# **MAWS.asmx.cs**
> Entry point for MAWS. 

* When you make a MAWS request via a ScriptLink event, this is where that request ends up.
* Both the `GetVersion()` and `RunScript()` methods are required by myAvatar™, and MAWS (or any web service that myAvatar references) cannot function without them.
* In order to keep this class short, most requests are processed by outside methods/classes.

***

## MAWSC.GetVersion()
> Returns the version of MAWS.

* This method is required by myAvatar.
* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return "VERSION 2.0".
* You can find more information about this method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method).

***

## MAWSC.RunScript()
> Executes a MAWS Request.

1. Sets up a few nice looking names for values we'll be using.
2. Creates a new OptionObject 2015 object that we will use to do the necessary work, and intializes it.
3. Determines the MawsMode to be used, and depending on the mode:
    - `enabled` This is the default setting, which processes MAWS requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    - `disabled` Skip all MAWS functionality. Essentially MAWS will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call MAWS, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    - `passthrough` Use MAWS, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since MAWS will actually go through the motions and write logs normally.
4. Returns an OptionObject2015 (which may or may not be modified) object to myAvatar.

* This method is required by myAvatar.
* You can find more information about this method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method).