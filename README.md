

---

# 🍕 Pizza Order System

A modern, robust, and interactive **Windows Forms (WinForms)** application built with **C#**. This project demonstrates clean software architecture, utilizing the **Divide and Conquer** principle to manage complex pricing logic and dynamic UI updates efficiently.

## 🚀 Overview

The **Pizza Order System** allows users to customize their pizza orders in real-time. From selecting the crust type and size to picking specific toppings, the application provides immediate visual feedback and live price calculation. It culminates in a detailed summary view before the final checkout.

## ✨ Key Features

* **Real-Time Price Calculation:** The total price updates instantly as the user toggles checkboxes or radio buttons.
* **Dynamic Summary Generation:** The summary form automatically formats itself based on user selection, including smart font resizing for long lists of toppings.
* **Interactive UI:** Controls are automatically disabled upon checkout to prevent modification during the finalization process.
* **Smart Validation:** Prevents zero-value orders and confirms actions via intuitive dialog boxes.
* **Reset Functionality:** A one-click reset feature to restore the form to its default state without restarting the app.

## 🛠 Architecture & Design Principles

This project is built with a strong focus on **Code Quality** and **Maintainability**:

### 1. Divide and Conquer Strategy ⚔️

Instead of one massive function calculating everything, the logic is broken down into small, manageable units. This makes the code easier to read and debug.

* `calculateSizePrice()`
* `calculateToppingsPrice()`
* `calculateCrustTypePrice()`

### 2. Single Responsibility Principle (SRP) 🎯

Every method has **one specific job**.

* **Calculation Methods:** Only return numbers (Float). They do not touch the UI.
* **Update Methods:** Only update the visual components (Labels/Summary). They do not perform calculations.
* **Event Handlers:** Only trigger the necessary update methods.

### 3. Modular Event Handling

The code avoids repetition by centralizing logic. For example, checking a topping triggers a unified update chain:
`CheckedChanged` ➔ `updateToppings()` ➔ `calculateTotalPrice()`

## 📂 Project Structure

Here is an overview of the files included in the solution:

### **Core Logic (Provided)**

* **`frmPizzaMain.cs`**: The main entry dashboard. A clean landing page to welcome the user.
* **`frmMenu.cs`**: The brain of the application. Handles all the business logic, state management, and price calculations using `Tag` properties for data storage.
* **`frmSummary.cs`**: A dedicated form for the final receipt. It includes UI logic to handle text overflow (Auto-font resizing).

### **Standard System Files (Implicit)**

* **`Program.cs`**: The entry point of the application (Main Loop).
* **`*.Designer.cs`**: (e.g., `frmMenu.Designer.cs`) Contains the auto-generated code that defines the GUI layout, buttons, and properties.
* **`*.resx`**: Resource files storing images, icons, and string localizations.
* **`PizzaOrderProject.csproj`**: The project configuration file linking all dependencies.

## 💻 Code Snippet Highlights

**Clean Calculation Logic:**

```csharp
private void calculateTotalPrice()
{
    // Aggregates results from smaller, independent functions
    float total = calculateCrustTypePrice() + calculateSizePrice() + calculateToppingsPrice();
    lblTotPrice.Text = total.ToString();
}

```

**Smart UI Adaptation (in Summary):**

```csharp
// Automatically shrinks font size if toppings list is too long
if (lblToppings.Right >= groupBox2.ClientSize.Width - 2)
{
    lblToppings.Font = new Font(lblToppings.Font.FontFamily, 7);
}

```

## 🚀 How to Run

1. **Clone the repository:**
```bash
git clone https://github.com/Ali-kanjo/PizzaOrder.git

```


2. **Open the Solution:**
Open `PizzaOrderProject.sln` in **Visual Studio 2022** (or later).
3. **Build & Run:**
Press `F5` or click the **Start** button.

## 🛡 License


---

