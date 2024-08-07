## Gravel Pit Client Application

Welcome to the Gravel Pit Client Application project! This Windows Forms application provides functionalities for managing gravel pit orders and interacting with the Gravel Pit Server API. The project was developed using Visual Studio and is intended for managing orders in a user-friendly interface.

## Table of Contents

- [Overview](#overview)
- [Getting Started](#getting-started)
- [Features](#features)
- [Configuration](#configuration)
- [License](#license)

## Overview

The Gravel Pit Client Application allows users to manage gravel pit orders through a Windows Forms interface. It integrates tightly with the Gravel Pit Server API to fetch and manipulate order data. The application supports various functionalities, including searching for orders, exporting reports, and editing client details.

## Getting Started

To get started with the Gravel Pit Client Application, follow these steps:

1. **Clone the Repository:**

   ```git clone https://github.com/cztgmng/GravelPitClient.git```

2. **Navigate to the Project Directory:**

   ```cd GravelPitClient```

3. **Open the Project:**

   Open the solution file (`GravelPit.sln`) in Visual Studio.

4. **Build and Run the Project:**

   Build the project and run it from Visual Studio. Ensure that you have the Gravel Pit Server API running and accessible.

## Features

The application provides the following features:

- **Client Management:** View and edit client details.
- **Order Management:** Search for orders by client and date range, and view detailed order information.
- **Reporting:** Export order summaries and details to HTML files.
- **Localization:** Supports multiple languages with dynamic translation.

## Configuration

The application configuration is managed through settings in the code. Key settings include:

To set up the API URL, you need to modify the `MainUrl.cs` file. The application will automatically use this URL to interact with the server.

## License

This project is licensed under the Creative Commons Attribution-NonCommercial 4.0 International License. See the [LICENSE](LICENSE) file for details.
