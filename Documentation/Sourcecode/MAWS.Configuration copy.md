<!-- b220624.102340 -->

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS.Configuration**

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

# `NAMESPACE` MAWS.Configuration
The **MAWS.Configuration** namespace handles any logic related to configuration files and settings.

### MAWS configuration files
There will be more information about how configuration files work here soon.

### Namespace classes

| Name | Description |
| ---- | ----------- |
| [MawsSession.cs](#mawsconfigurationmawssessioncs) | Logic for current MAWS session variables |
| [SettingsFile.cs](#mawsconfigurationsettingsfilecs) | Logic for MAWS configuration files |

## `CLASS` MawsSession.cs
This class handles anything related to the current MAWS session variables.

### Class methods

| Name | Description |
| ---- | ----------- |
| [MawsSession.Build](#mawsconfigurationmawssessioncs) | Get MAWS session information |

### `METHOD` Build()
This method gets the setting for a specific MAWS session.

#### Details
No details.

#### Notes
* This doesn't return anything (220621).

## `CLASS` SettingsFile.cs
This class handles anthing related to the configuration file.

### `METHOD` Build()
> Get the MAWS session information.

#### Details
1. Return a dictionary with the following setting values:
    - `MawsMode`
    - `LogMode`
    - `MawsRootDir`
    - `FallbackAvatarUserName`

#### Notes
* These settings are derived from the configuration file, but we need to confirm that making changes to the local config file override these.

***

[MAWS](https://github.com/spectrum-health-systems/MAWS) &gt; [Sourcecode](../Sourcecode/MAWS-Sourcecode.md) &gt;  **MAWS.Configuration**