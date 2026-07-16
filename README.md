# Lobby Radio Player v1.0

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![Platform: Windows](https://img.shields.io/badge/Platform-Windows-blue.svg)]()
[![Framework: .NET Framework 4.7.2](https://img.shields.io/badge/Framework-.NET%20Framework%204.7.2-purple.svg)]()

---

## What does it look like?

<img width="273" height="274" alt="Screenshot_15" src="https://github.com/user-attachments/assets/f8706578-6966-486b-88fc-0cea38403016" />

*A clean, distraction-free interface. No bloated settings, no confusion—ready to roll in three clicks.*

---

## Why I built this? (The Problem)

This project started because of a very specific, real-world headache. **I needed to set up background music for a local business and automatically inject a promotional audio ad every few minutes.** 

When I looked online for a solution, I was honestly shocked. Every software capable of doing this was either:
1. Locked behind an expensive, recurring monthly subscription.
2. Built for massive radio stations, looking like the control panel of a nuclear power plant.
3. Way too complicated for the non-tech-savvy staff working at the venue.

I just wanted something **dead simple, lightweight, and reliable** that "just works" on any Windows PC. Since I couldn't find a straightforward, free option...

**...I sat down, wrote it myself, and decided to share it with everyone for free.**

---

## What it solves & Why you'll love it

*   **100% Free & Open-Source:** No subscriptions, no registration, no hidden paywalls, and no annoying ads pushed by me. It's yours forever.
*   **Zero-Setup Autopilot:** You don't need an IT degree to run this. Just paste your radio stream link, pick your local `.mp3` or `.wav` ad file, set the interval in seconds, and hit **PLAY**. That's literally it.
*   **Seamless Transitions (No Awkward Cuts):** Most basic audio players just abruptly cut the music and blast the ad. This player smoothly fades out the stream (fade out), plays your ad, and gently fades the music back in (fade in). It sounds incredibly professional, just like a real radio station.
*   **No UI Freezing (Multithreaded Engine):** Have you ever had an app freeze and show that annoying Windows (Not Responding) window while loading a stream? Not here. All heavy lifting—network buffering, timers, and streaming—runs silently on background threads. The interface stays buttery smooth and responsive.
*   **Self-Healing Connection Guard:** If the venue's internet drops, the player won't crash or freeze. A background watchdog quietly attempts to reconnect every 5 seconds until the music starts playing again.

---

## Cool Features Under the Hood

*   **Active Hours Scheduler:** Set your operating hours (e.g., `08:00` to `23:00`). The program will automatically put itself on standby when the venue closes and wake up on time when the morning shift starts—saving internet bandwidth and system resources.
*   **Independent Volume Controls:** Set a comfortable, low background music level for your guests, while making the advertisements slightly louder and clearer so they actually get noticed.

---

## Hardware & Setup Requirements

Before clicking play, please make sure of two things:
1.  **Sound System Connection:** The computer running this application **must be physically connected** to your venue's amplifier, mixer, or central sound system (via a 3.5mm AUX jack, Bluetooth, USB DAC, or HDMI) to broadcast the audio.
2.  **Windows Audio Settings:** Ensure your central sound system is set as the "Default Device" in Windows Sound Settings before running the player.

---

## How to Download & Run

You don't need to compile any code or install complicated development tools. Head over to the **[Releases](https://github.com/0xVasic/lobby-radio-player/releases/tag/v1.0)** section where two pre-built options are waiting for you:

### Option 1: Windows Installer (Recommended)
1.  Go to **[Releases](https://github.com/0xVasic/lobby-radio-player/releases/tag/v1.0)** and download `lrp_setup.exe`.
2.  Run the installer and follow the simple setup wizard.
3.  Launch the application using the Desktop shortcut.

### Option 2: Portable Version (No Installation)
1.  Go to **[Releases](https://github.com/0xVasic/lobby-radio-player/releases/tag/v1.0)** and download `LobbyRadioPlayer_v1.0_Portable.zip`.
2.  Extract the ZIP archive anywhere (even on a USB flash drive).
3.  Double-click `Lobby Radio Player.exe` and enjoy!

---

## Technical Details (For Developers)

If you want to play around with the code or see how things work under the hood:
*   **Language:** VB.NET (Windows Forms)
*   **Framework:** .NET Framework 4.7.2 (Ensures compatibility out-of-the-box on almost any Windows 10/11 machine without downloading extra runtimes)
*   **Audio Engine:** NAudio (MediaFoundationReader & WaveOutEvent)
*   **Installer Engine:** Inno Setup

---

## License & Legal Disclaimer

This project is completely free and open-source under the **MIT License** (feel free to use, modify, and share the code however you like).

> **Important Legal Notice:** While I am sharing this tool completely free of charge, you as the business/venue owner are solely responsible for obtaining any required commercial music licenses (such as local copyright collective societies, e.g., SOKOJ, OFPS, or equivalent in your country) and broadcast permissions for public commercial spaces.

---

*Developed with ❤️ by **Djordje Vasic** — [Cyformat Digital Agency](https://www.cyformat.rs)*
