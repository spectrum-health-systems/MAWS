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

# NAMESPACES
* [MAWS](MAWS.md)
* [MAWS.Configuration](MAWS.Configuration.md)

# ADDITIONAL READING
It may be helpful to review the [Creating a Custom Web Service](
https://github.com/myAvatar-Development-Community/document-creating-a-custom-web-service) documentation.

Also, there is quite a bit of myAvatar-related information/documentation at the [myAvatar Development Community](
https://github.com/myAvatar-Development-Community/).

***

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **Sourcecode documentation**