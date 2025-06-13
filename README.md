<!--
  🚀 PublicacionesApp – Technical README
  ======================================
  A modern, technical overview of the .NET MAUI MVVM sample app
-->

# 🚀 PublicacionesApp

![.NET MAUI 8.0](https://img.shields.io/badge/.NET_MAUI-8.0-blue?style=flat-square) ![C#](https://img.shields.io/badge/C%23-9B4F96?style=flat-square) ![MIT License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

> A cross-platform academic publications manager built with **.NET MAUI** and **MVVM**.

---

## 📐 Table of Contents

1. [🎯 Objective](#-objective)
2. [🧩 Architecture](#-architecture)
3. [📂 Project Structure](#-project-structure)
4. [⚙️ Prerequisites](#️-prerequisites)
5. [🚀 Getting Started](#-getting-started)
6. [📈 Usage Flows](#-usage-flows)
7. [🛠️ Customization & Styling](#️-customization--styling)
8. [🤝 Contributing](#-contributing)
9. [📄 License](#-license)
10. [✍️ Author](#️-author)

---

## 🎯 Objective

Provide a fully functional **CRUD** app for academic publications, demonstrating:

* **MVVM** pattern
* **Shell** navigation
* In-memory **Service** layer
* Custom **Styles** & **Converters**
* Cross-platform UI (Windows, Android, iOS)

---

## 🧩 Architecture

```mermaid
flowchart LR
    A[Views (XAML + Code-Behind)] -->|binds to| B(ViewModels)
    B -->|calls| C[IPublicationService]
    C -->|manipulates| D[(In-Memory Data Store)]
    D --> C
    C -->|returns| B
    B -->|updates| A
```

* **Views**: `*.xaml` + code-behind
* **ViewModels**: inherit `BaseViewModel` (INotifyPropertyChanged, Title, IsBusy)
* **Service**: `IPublicationService` + `PublicationService` singleton
* **Models**: `Publication`, `PublicationType`, `PublicationStatus`

---

## 📂 Project Structure

```
/PublicacionesApp
│
├── App.xaml                     # Global resources & converters
├── MauiProgram.cs               # App startup, fonts & DI registrations
│
├── Models/
│   └── Publication.cs           # Data model + enums
│
├── Services/
│   ├── IPublicationService.cs
│   └── PublicationService.cs
│
├── ViewModels/
│   ├── BaseViewModel.cs
│   ├── PublicationsListViewModel.cs
│   ├── PublicationDetailViewModel.cs
│   ├── AddPublicationViewModel.cs
│   ├── AddAuthorViewModel.cs
│   ├── FilterByTypeViewModel.cs
│   ├── SearchByAuthorViewModel.cs
│   ├── ChangeStatusViewModel.cs
│   └── DeletePublicationViewModel.cs
│
├── Views/
│   ├── PublicationsListPage.xaml
│   ├── PublicationDetailPage.xaml
│   ├── AddPublicationPage.xaml
│   ├── AddAuthorPage.xaml
│   ├── FilterByTypePage.xaml
│   ├── SearchByAuthorPage.xaml
│   ├── ChangeStatusPage.xaml
│   └── DeletePublicationPage.xaml
│
└── Resources/
    ├── Styles/Styles.xaml        # Color palette & control styles
    ├── Converters/               # IValueConverters (InverseBool, StringNotNullOrEmpty, NotNullToBool)
    └── Fonts/Orbitron-Regular.ttf
```

---

## ⚙️ Prerequisites

* **Windows 11 / macOS / Linux**
* **.NET 8.0 SDK**
* **Visual Studio 2022 Community** v17.14.5 with **.NET MAUI** workload
* (Optional) Android Emulator or physical device

---

## 🚀 Getting Started

```bash
# 1. Clone the repo
git clone https://github.com/almarar10/PublicacionesApp.git

# 2. Navigate into project
cd PublicacionesApp

# 3. Open in Visual Studio 2022
#    - Select "Windows Machine" or an Android emulator
#    - Press F5 to build and run
```

---

## 📈 Usage Flows

1. **List Publications**

   * Displays cards with Title, Type, Status.
   * Tap a card → ✨ Prompt "View details?" → Yes → Navigate to detail view.

2. **Create Publication**

   * Fill ID, Title, Date, Type, Status, Authors.
   * Press “Save” → Publication added in-memory.

3. **Replace Author**

   * Select a publication from picker.
   * Enter new author name → Press “Replace” → Old authors cleared + new author added.

4. **Filter by Type**

   * Choose a type from dropdown → Press “Filter” → List shows matching items.

5. **Search by Author**

   * Enter author name → Press “Search” → List shows publications containing that author.

6. **Change Status**

   * Search by ID or Title → Select new status from dropdown → Press “Update”.

7. **Delete Publication**

   * Enter Title → Press “Search” → Confirm deletion → Publication removed.

---

## 🛠️ Customization & Styling

* **Fonts**: `Orbitron` for a distinctive “metallic orange” look
* **Colors**:

  * Background: `#1E1E1E`
  * Accent (orange): `#FF8C00`
* **Styles**: centralized in `Resources/Styles/Styles.xaml`
* **Converters**: reusable IValueConverters in `Resources/Converters`

---

## 🤝 Contributing

1. Fork the repo
2. Create a feature branch:

   ```bash
   git checkout -b feature/awesome-feature
   ```
3. Commit your changes:

   ```bash
   git commit -m "Add awesome feature"
   ```
4. Push to GitHub:

   ```bash
   git push origin feature/awesome-feature
   ```
5. Open a Pull Request

---

## 📄 License

This project is licensed under the **MIT License**:

```
MIT License

Copyright (c) 2025 almarar10

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files...
... (rest of the MIT text)
...
```

---

## ✍️ Author

**almarar10**

* GitHub: [@almarar10](https://github.com/almarar10)
* Email: [your.email@example.com](mailto:your.email@example.com)

---

👩‍💻 **Happy coding!**
