<!-- b220621.115657 -->

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS.Configuration**

***

<br>

# **MAWS.Configuration.MawsSession.cs**

## MAWS.Configuration.MawsSession.Build()
* This doesn't return anything (220621)

***

<br>

# **MAWS.Configuration.SettingsFile.cs**

## MAWS.Configuration.SettingsFile.Build()
1. Return a dictionary with the following setting values:
    - `MawsMode`
    - `LogMode`
    - `MawsRootDir`
    - `FallbackAvatarUserName`

* These settings are derived from the configuration file, but we need to confirm that making changes to the local config file override these.

***