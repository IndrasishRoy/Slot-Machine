# Slot Machine

## 🎮 Game Overview

This project is a simple 3-reel slot machine built in Unity and exported as a WebGL build.

The goal of the game is straightforward:

- Click the slot machine handle.
- Watch the reels spin.
- If all three symbols match, you win.
- If they do not match, you lose.

The project focuses on:
- Smooth reel animation
- Accurate symbol alignment
- Frame-rate independent spinning
- Clean separation between spin logic and result detection

The reel system uses smooth deceleration and easing alignment to simulate a mechanical slot machine feel.

---

## 📦 WebGL Build Location

The WebGL build is located at:

Build/WebGL/Slot Machine.zip

To use or run the build:

1. Navigate to the location above.
2. Extract (unzip) the `Slot Machine.zip` file.
3. Open the extracted folder.
4. Follow the instructions below to run the WebGL build using a local server.

---

## 🌐 Instructions to Run WebGL Build

⚠️ Important: WebGL builds must be run from a local or hosted server.  
Do **not** open `index.html` directly by double-clicking.

### Run with VS Code Live Server

1. Open the WebGL build folder in Visual Studio Code.
2. Install the **Live Server** extension.
3. Right-click `index.html`.
4. Click **"Open with Live Server"**.

---

## 🧠 Thought Process & Approach

The main goal of this project was to create a smooth and visually convincing slot machine using Unity’s WebGL platform.

### 1️⃣ Spin System Design

Initially, reel movement was step-based using fixed intervals.  
However, this caused:

- Inconsistent stopping
- Visual snapping
- WebGL timing jitter

To fix this, the system was redesigned to use:

- Frame-based movement
- Speed-based spinning
- Gradual deceleration
- Smooth easing alignment to center symbols

This made the spin feel natural and consistent across frame rates.

---

### 2️⃣ Symbol Detection

Instead of relying on physics triggers (`OnTriggerEnter2D`) to detect the final symbol, the system now:

- Calculates the closest symbol to the frame center
- Smoothly aligns the reel to that symbol
- Then reports the result

This ensures:
- Visual accuracy
- Deterministic behavior
- No frame-rate dependency

---
## 🖱️ Controls

| Action | Input |
|--------|--------|
| Spin Reels | Click the slot machine handle |

No keyboard input required.

---

## 🏆 Win Condition

You win if all three reels stop on the same symbol.

Otherwise, you lose.

---

Enjoy spinning! 🎰
