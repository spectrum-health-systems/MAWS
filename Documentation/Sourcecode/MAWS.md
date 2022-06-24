<!-- b220624.102340 -->

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS namespace**

***

<br>

<div align="center">

  <img src="../../.github/Resources/Assets/Logos/maws-logo-web-service-512x256.png" alt="MAWS logo" width="256">
  <h1> 
    SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)](https://github.com/spectrum-health-systems/MAWSC)&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)](../Manual/MAWSC-Manual.md)&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)](MAWSC-Sourcecode.md)

</div>

<br>

# **MAWS** NAMESPACE
The MAWS namespace is the entry point for MAWS. When you make a MAWS request via a ScriptLink event, this is where that request ends up.

As it is mostly a "clearing house" for MAWS Requests, there is only one class (`MAWS.asmx.cs`) and two methods ("`GetVersion()`", "`RunScript()`"), and those methods are fairly generic - all other functionality and logic is handled by external code. This means that things here rarely change, so ScriptLink events have a known, stable target.

#### Important!

Please note that both the `GetVersion()` and `RunScript()` methods are required by myAvatar™, and MAWS (or any web service that myAvatar references) cannot function without them.

## MAWS.asmx.cs

### MAWSC.GetVersion()
> Returns the version of MAWS.

#### Details
This method is pretty straight forward, and doesn't change.

#### Notes
* This method is required by myAvatar.
* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return "VERSION 2.0".
* You can find more information about this method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method).

### MAWSC.RunScript()
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

***

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS**