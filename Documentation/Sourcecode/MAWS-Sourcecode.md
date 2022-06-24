<!-- b220624.102340 -->

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **Sourcecode documentation**

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

# ABOUT THIS DOCUMENT
This is detailed documentation about the MAWS sourcecode, which includes:

* Information about sourcecode [comments](#sourcecode-comments) and [variables](#variables).
* Detailed information about each [namespace](#namespaces), and the classes and methods within.

# SOURCECODE COMMENTS
Attempts have been made to make the MAWS sourcecode as human-readable as possible, so I'm keeping the comments to a minimum. The document you are currently reading is the primary source of information about how everything works.

That being said, you will find the following types of comments in the MAWS sourcecode:
```
/// XML comments used by Visual Studio

// Additional code description comment

/* Single-line narrative comment */

/* Multiple-line
 * narrative comment
*/

```

# VARIABLES

## Standard casing/whitespace
Most logic in MAWS is checked against lowercase values without any leading/trailing whitespace, so (in general) MAWS will reduce a variable to its trimmed, lowercase value. This is done as soon as possible, usually when a variable is declared.

For example, one of the first things MAWS does when it executes is to get the `mawsMode` from the settings file, and that value *should* be lowercase. But since it would be a bad idea to assume that - since anything other than a lowercase value without leading/trailing whitespace will cause errors, we will force `.Trim().ToLower()`.

## Variable prefixes

### "Sent" variables
If a variable name starts with "sent" (e.g., `"sentOptObj"`), the data it contains is the original data sent from myAvatar. These values should not be modified at any point.

For example, the `"sentMawsRequest"` will always be the value sent via a ScriptLink event, and therefore you can always determine what the original MAWS request was.

# ADDITIONAL READING
It may be helpful to review the [Creating a Custom Web Service](
https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service) documentation.

Also, there is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](
https://github.com/myAvatar-Development-Community/).

# NAMESPACES
[MAWS](#maws)<br>
[MAWS.Configuration](#mawsconfiguration)

## NAMESPACE: MAWS
The MAWS namespace is the entry point for MAWS. When you make a MAWS request via a ScriptLink event, this is where that request ends up.

Both the `GetVersion()` and `RunScript()` methods are required by myAvatar™, and MAWS (or any web service that myAvatar references) cannot function without them.

In order to keep this class short, most requests are processed by outside methods/classes.

### CLASS: MAWS.asmx.cs

#### METHOD: MAWSC.GetVersion()
> Returns the version of MAWS.

* This method is required by myAvatar.
* The version number doesn't change during development. For example, while developing v2.0.x.x, this method will aways return "VERSION 2.0".
* You can find more information about this method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-getversion-method).

#### METHOD: MAWSC.RunScript()
> Executes a MAWS Request.

1. Sets up a few nice looking names for values we'll be using.
2. Creates a new OptionObject 2015 object that we will use to do the necessary work, and intializes it.
3. Determines the MawsMode to be used, and depending on the mode:
    - `enabled` This is the default setting, which processes MAWS requests normally, returns a modified OptionObject2015 to myAvatar, and logs everything.
    - `disabled` Skip all MAWS functionality. Essentially MAWS will recieve the sentOptObj, then skip directly to finalizing and returning the retOptObj, so no changes are made. This should be used when you don't want myAvatar to call MAWS, but you don't want to disable scripts on every form you use  anything, including writing logs (aside from basic, informational logs).
    - `passthrough` Use MAWS, but don't make changes, only write logs. This is like the "disabled" setting, since no modifications to the OptionObject are make, and also like the "enabled" setting, since MAWS will actually go through the motions and write logs normally.
4. Returns an OptionObject2015 (which may or may not be modified) object to myAvatar.

* This method is required by myAvatar.
* There is a commented line is at the start of the method that enables troubleshooting logs. This line shoudl remain commented in production.
* You can find more information about this method [here](https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service#the-runscript-method).

****

## MAWS.Configuration
* Does things with configuration settings and files.

### MAWS.Configuration.MawsSession.cs
> Get the MAWS session information.

#### MAWS.Configuration.MawsSession.Build()
* This doesn't return anything (220621)

### MAWS.Configuration.SettingsFile.cs

#### MAWS.Configuration.SettingsFile.Build()
1. Return a dictionary with the following setting values:
    - `MawsMode`
    - `LogMode`
    - `MawsRootDir`
    - `FallbackAvatarUserName`

* These settings are derived from the configuration file, but we need to confirm that making changes to the local config file override these.