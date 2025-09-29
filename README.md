# Real-Time Chat Application

[![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![SignalR](https://img.shields.io/badge/SignalR-0078D4?style=for-the-badge&logo=microsoft&logoColor=white)](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction?view=aspnetcore-8.0)
[![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)](https://learn.microsoft.com/en-us/dotnet/csharp/)

A modern, real-time chat application built with **ASP.NET Core Razor Pages** and powered by **SignalR**. This project offers instant messaging capabilities and ensures that the entire chat history is preserved and seamlessly loaded, providing a continuous and up-to-date conversation experience.

---

## ✨ Features

* **Real-Time Messaging:** Instant, low-latency communication thanks to **SignalR**.
* **Persistent History:** All messages are saved and displayed upon joining/reloading, ensuring you never miss a beat.
* **Live Updates:** New messages are instantly visible to all active participants without the need to refresh.
* **Razor Pages Architecture:** Clean, model-view approach for easy management of UI and server-side logic.

---

## 🛠️ Getting Started

### Prerequisites

To run this project locally, you need the following installed:

* **.NET SDK** (version 9.0 is recommended)
* A code editor like **Visual Studio** or **VS Code**

### Installation and Setup


1.  **Clone the repository:**
    ```bash
    git clone [https://github.com/philchan2008/signalRChatApp.git](https://github.com/philchan2008/signalRChatApp.git)
    cd signalRChatApp 
    ```

2.  **Restore dependencies:**

*dotNet Package Installation*

```bash
dotnet add package Microsoft.AspNetCore.SignalR
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Extensions.Localization
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitChatSchema
dotnet ef database update
```

```bash
dotnet restore
```



3.  **Update Database (for History Persistence):**
    This project uses a database (e.g., SQLite or SQL Server via Entity Framework Core) to store chat history.

    * Ensure your connection string in `appsettings.json` is correctly configured.
    * Run Entity Framework Core migrations to create the database:
        ```bash
        dotnet ef database update
        ```

4.  **Run the application:**
    ```bash
    dotnet run
    ```
    The application will typically be available at `http://localhost:5000` or the port specified in your configuration.

---

## 💻 Project Structure

The key components of the project are:

* **`Pages/`:** Contains the Razor Pages (`.cshtml` and `.cshtml.cs` files) that handle the UI and page-specific logic, including the main chat page.
* **`Data/`:** Holds the **`DbContext`** and **`Message`** entity/model used by Entity Framework Core to interact with the database for saving and retrieving chat history.
* **`Hubs/`:** Contains the **`ChatHub.cs`** class, which is the central **SignalR Hub** that manages real-time connections and message broadcasting.
* **`wwwroot/js/`:** Includes the client-side JavaScript that establishes the SignalR connection, sends messages, and handles the live appending of new messages to the chat window.

---

## 🚀 Usage

To be updated...

---

## 📄 License

Distributed under the **MIT License**. See `LICENSE` for more information.

---

## 📞 Contact

Your Name - philchan2008@gmail.com - https://linkedin.com/wt-philip-chan/

Project Link: [https://github.com/philchan2008/signalRChatApp](https://github.com/philchan2008/signslRChatApp)

