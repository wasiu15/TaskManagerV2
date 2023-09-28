# Task Manager Application

A Task Manager Application that helps users manage their tasks efficiently.

## Table of Contents
- [Project Overview](#project-overview)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Features](#features)
- [Architecture](#architecture)
- [Database](#database)
- [Solid Principles](#solid-principles)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Project Overview

This Task Manager Application allows users to create and manage tasks. It follows the principles of clean architecture, separating business logic from the data access layer. SQLite is used as the lightweight database for quick task management.

When creating a new task, users are required to enter the following information:
- Task Name
- Description
- Allotted Time

The application automatically generates the following properties:
- Task ID (Unique)
- Start Date (Automatically set to the creation date)
- Elapsed Time (Calculated later in the app)
- Task Status (Defaulted to false on task creation)

## Getting Started

### Prerequisites

Before running the application, make sure you have the following prerequisites installed:

- [List prerequisites here]

### Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/wasiu15/TaskManagerV2.git


2. Build the application to install all dependencies.

3. Run the following command in the Package Manager Console to set up the SQLite database:

   ![image](https://github.com/wasiu15/TaskManagerV2/assets/66498295/485f8704-e3a4-45d2-b5c6-d1ea499b0003)

4. Database
   SQLite is used as the database for this application.

5. Solid Principles
   The SOLID principles are followed in the design and development of this application.
