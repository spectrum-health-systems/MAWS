> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS.Logging**

<br>
<br>
<div align="center">
  <img src="../../.github/Logos/maws-logo-web-service-512x256.png" alt="MAWSC logo" width="256">
  <h1> 
    MAWS SOURCODE DOCUMENTATION
  </h1>

  [![REPOSITORY](https://img.shields.io/badge/REPOSITORY-550055?style=for-the-badge)][1]&nbsp;&nbsp;&nbsp;[![MANUAL](https://img.shields.io/badge/MANUAL-550055?style=for-the-badge)][3]&nbsp;&nbsp;&nbsp;[![SOURCECODE-DOCUMENTATION](https://img.shields.io/badge/SOURCECODE%20DOCUMENTATION-8e008e?style=for-the-badge)][2]

</div>

<div align="center">

# **`NAMESPACE`** MAWS.Logging

</div>

# About this namespace

Logic for the MAWS logging functionality.

# Classes

<details>
<summary>
  <b>Breadcrumb.cs</b><br>
  <i>Logic for creating breadcrumb/tracing logs.</i>
</summary>

***

### `Trace()`

Create an data dump logfile.

#### Operation

1. Create a data dump message.
2. Verify the "C:/MAWS/Datadump/" directory exists.
3. Write the data dump message to a local file.

#### Notes

* This method is only used for debugging, and should not be used in production.
* You can use this functionality anywhere by placing the line `Logging.DataDump.WriteDump();` where you want the data dump to take place.
* **\[2]** This is a failsafe to make sure that the "C:/MAWS/Datadump/" exists prior to writing to it.
* **\[3]** The logfile is always written to "C:/MAWS/Datadump/"

</details>

***

<details>
<summary>
  <b>DataDump.cs</b><br>
  <i>Logic for creating data dumps for troubleshooting.</i>
</summary>

***

### `DataDump()`

Create an data dump logfile.

#### Operation

1. Create a data dump message.
2. Verify the "C:/MAWS/Datadump/" directory exists.
3. Write the data dump message to a local file.

#### Notes

* This method is only used for debugging, and should not be used in production.
* You can use this functionality anywhere by placing the line `Logging.DataDump.WriteDump();` where you want the data dump to take place.
* **\[2]** This is a failsafe to make sure that the "C:/MAWS/Datadump/" exists prior to writing to it.
* **\[3]** The logfile is always written to "C:/MAWS/Datadump/"

</details>

<br>

***

> [MAWS][1] &gt; [Sourcecode documentation][2] &gt; **MAWS.Logging**

[1]: https://github.com/spectrum-health-systems/MAWS
[2]: ../Sourcecode/MAWS-Sourcecode.md
[3]: ../Manual/MAWS-Manual.md
[4]: ../Sourcecode/MAWS-Sourcecode.md#standard-casingtrimming-of-values

<div align="center">
  <sub>
    Last updated July 6th, 2022
  </sub>
<br>