# Lobby Radio Player v1.0 

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Platform: Windows](https://img.shields.io/badge/Platform-Windows-blue.svg)]()
[![Framework: .NET Framework 4.7.2](https://img.shields.io/badge/Framework-.NET%20Framework%204.7.2-purple.svg)]()

## Why I built this?

I built this app because of a very specific, real-world headache: **I needed to set up background music for a local venue and automatically inject promotional ad every few minutes.** 

When I looked for a solution, I realized that every software capable of doing this is either locked behind an expensive monthly subscription, targeted at massive enterprise systems, or incredibly overcomplicated to set up. I just wanted something simple, lightweight, and reliable that "just works" on any Windows PC. 

Since I couldn't find a straightforward, free option - **I decided to build it myself and share it with everyone.**

---

## What it solves & Why it’s the perfect choice:

*   **Completely Free & Open-Source:** No subscriptions, no registration, and no hidden fees.
*   **Zero-Setup Autopilot:** You don't need a degree in IT. Just paste your radio stream link, select your local `.mp3` or `.wav` ad file, set the interval in seconds, and hit **PLAY**.
*   **Seamless Transitions (No Awkward Silences):** Most basic players just cut the music and play the ad. This player smoothly fades out the music, plays your ad, and gently fades the music back in.
*   **Ultra-Lightweight & Bulletproof:** Written in VB.NET on .NET Framework 4.7.2, it runs on almost any Windows machine without freezing the user interface, and automatically heals/reconnects if the internet drops.

---

## Key Features & Capabilities

*   **Multithreaded Connection Engine:** All streaming operations, network buffering, and reconnection watchdog tasks run entirely on background threads. The user interface remains 100% responsive—no application freezing, lag, or loading cursors.
*   **Smart Ad Injection (Fade In/Out):** To guarantee a premium customer experience, the system automatically and smoothly fades out the live stream before playing a local advertisement, and gently fades the music back in once the ad finishes.
*   **Active Hours Scheduler:** Set your venue's operating hours (e.g., `08:00` to `23:00`). The system automatically handles standby outside of these hours and wakes up instantly when the shift starts, saving bandwidth and system resources.
*   **Self-Healing Connection Guard:** Built-in watchdog timers actively monitor stream states. If your internet connection drops, the system stops current tasks and silently attempts reconnection every 5 seconds until the stream is restored.
*   **Independent Volume Controls:** Customize separate volume levels for both the background music and the local advertisements in real-time from the Settings panel.

---

## Hardware & Setup Requirements

Before starting the playback, please ensure:
1.  **Sound System Connection:** The computer running this application **must be physically connected** to your venue's amplifier, mixer, or central sound system (via a 3.5mm audio jack, Bluetooth, USB DAC, or HDMI) to broadcast the audio to your speakers.
2.  **Default Output Device:** Make sure your desired central sound system is set as the **Default Playback Device** in Windows Sound Settings before starting the program.

---

## Tech Stack & Dependencies

*   **Language:** VB.NET (Windows Forms)
*   **Framework:** .NET Framework 4.7.2
*   **Audio Library:** NAudio (MediaFoundationReader & WaveOutEvent)
*   **Installer Engine:** Inno Setup

---

## Download & Installation

You do **not** need to compile the source code to run the application. We offer two clean, pre-built distribution options in our **[Releases](https://github.com/0xVasic/lobby-radio-player/releases/tag/v1.0)** section:

### Option 1: Windows Installer (Recommended)
1.  Go to **[Releases](https://github.com/0xVasic/lobby-radio-player/releases/tag/v1.0)** and download `lrp_setup.exe`.
2.  Run the setup wizard (accept the MIT license, read the quick-start guide).
3.  Launch the application.

### Option 2: Portable Version (.zip)
1.  Go to **[Releases](https://github.com/0xVasic/lobby-radio-player/releases/tag/v1.0)** and download `LobbyRadioPlayer_v1.0_Portable.zip`.
2.  Extract the archive to any folder (or a USB drive).
3.  Double-click `Lobby Radio Player.exe` to run the program immediately (no installation required).

---

## Quick-Start Guide

1.  **Enter Stream Link:** Paste a direct audio stream URL into the *Link* field.
    *   *Note: Standard web player links from radio websites will not work. Use direct URL directories (e.g., links containing a port like `http://example.com:8000/stream` or ending with `.mp3`, `.aac`, `.pls`).*
2.  **Set Advertisement Interval:** Enter the desired delay between ads in seconds (e.g., `300` seconds for a 5-minute interval).
3.  **Choose Ad File:** Click the browse button to locate and select your local audio file (`.mp3` or `.wav`).
4.  **Start Autopilot:** Click **PLAY** to arm the system. Input fields will lock automatically to prevent accidental modifications during broadcasting. Click **STOP** to make adjustments.

---

## License & Legal Disclaimer

This project is open-source and licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

> **Legal Notice:** This utility is provided strictly "as-is". The end-user is entirely and solely responsible for acquiring any necessary public performance licenses, complying with national copyright laws, and obtaining appropriate broadcast permissions for commercial, public, or business environments.

---

*Developed with ❤️ by **Djordje Vasic** — [Cyformat Digital Agency](https://www.cyformat.rs)*
