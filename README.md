Here’s the complete **README.md** in plain Markdown—no rendering errors—ready to copy into your repository:

```markdown
# 🚀 PublicacionesApp

![.NET MAUI 8.0](https://img.shields.io/badge/.NET_MAUI-8.0-blue?style=flat-square) ![C#](https://img.shields.io/badge/C%23-9B4F96?style=flat-square) ![MIT License](https://img.shields.io/badge/License-MIT-green?style=flat-square)

> A cross-platform academic publications manager built with **.NET MAUI** and **MVVM**.

---

## 📐 Table of Contents

1. 🎯 Objective  
2. 🧩 Architecture  
3. 📂 Project Structure  
4. ⚙️ Prerequisites  
5. 🚀 Getting Started  
6. 📈 Usage Flows  
7. 🛠️ Customization & Styling  
8. 🤝 Contributing  
9. 📄 License  
10. ✍️ Author  

---

## 🎯 Objective

Provide a fully functional **CRUD** app for academic publications, demonstrating:

- **MVVM** pattern  
- **Shell** navigation  
- In-memory **Service** layer  
- Custom **Styles** & **Converters**  
- Cross-platform UI (Windows, Android, iOS)  

---

## 🧩 Architecture

```

Views (XAML + code-behind)
↓ binds to
ViewModels (BaseViewModel → specific logic)
↓ calls
IPublicationService → PublicationService (singleton)
↓ manipulates
In-Memory Data Store

```

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
├── Styles/Styles.xaml        # Color palette & styles
├── Converters/               # IValueConverters
└── Fonts/Orbitron-Regular.ttf

````

---

## ⚙️ Prerequisites

- **Windows 11 / macOS / Linux**  
- **.NET 8.0 SDK**  
- **Visual Studio 2022 Community** v17.14.5 with **.NET MAUI** workload  
- (Optional) Android Emulator or physical device  

---

## 🚀 Getting Started

```bash
# 1. Clone the repo
git clone https://github.com/almarar10/PublicacionesApp.git

# 2. Enter folder
cd PublicacionesApp

# 3. Open in Visual Studio 2022
#    - Select "Windows Machine" or an Android emulator
#    - Press F5 to build and run
````

---

## 📈 Usage Flows

1. **List Publications**

   * Shows cards with Title, Type, Status.
   * Tap a card, confirm “View details?”, then see full info.

2. **Create Publication**

   * Fill ID, Title, Date, Type, Status, Authors.
   * Tap **Save** → new item appears in list.

3. **Replace Author**

   * Pick a publication, enter new author name.
   * Tap **Replace** → old authors cleared, new author set.

4. **Filter by Type**

   * Choose a type, tap **Filter** → list filtered.

5. **Search by Author**

   * Enter author name, tap **Search** → show matching items.

6. **Change Status**

   * Search by ID or Title, pick new status, tap **Update**.

7. **Delete Publication**

   * Search by Title, tap **Delete**, confirm → item removed.

---

## 🛠️ Customization & Styling

* **Fonts**: `Orbitron` for a metallic-orange look
* **Colors**:

  * Background: `#1E1E1E`
  * Accent: `#FF8C00`
* **Styles**: in `Resources/Styles/Styles.xaml`
* **Converters**: in `Resources/Converters`

---

## 🤝 Contributing

1. Fork the repo
2. Create a feature branch:

   ```bash
   git checkout -b feature/awesome
   ```
3. Commit your changes:

   ```bash
   git commit -m "Add awesome feature"
   ```
4. Push and open a PR

---

## 📄 License

This project is licensed under the **MIT License**.
See [LICENSE](LICENSE) for full text.

---

## ✍️ Author

**almarar10**

* GitHub: [@almarar10](https://github.com/almarar10)
* Email: [your.email@example.com](mailto:your.email@example.com)

---

👩‍💻 **Happy coding!**

```
```
