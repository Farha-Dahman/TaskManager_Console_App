# Task Manager Console Application 

## Overview

The Task Manager Console Application is a simple, interactive command-line tool that allows users to manage tasks efficiently. With this application, you can create, view, update, delete, and search tasks, as well as track your progress.

## Features

- Add Task: Create a new task with a title, description, due date, priority, status, and category.

- View Tasks: Display all tasks with filtering options (e.g., by status, priority, or category).

- Update Task: Modify details of an existing task.

- Delete Task: Remove a task from the list.

- Search Tasks: Search for tasks by keyword.

- Show Progress: View your task completion rate.

- Save and Load: Persist tasks between sessions using a JSON file.

## How to Run
1. Clone this repository or download the source code.
2. Open the project in Visual Studio.
3. Build and run the application.
4. Follow the menu options in the console.

## Usage
1. Select an option from the menu.
2. Follow prompts to add, update, view, or delete tasks.
3. Use the search feature to find tasks or view progress to see the completion rate.

## Technologies Used
- C#
- JSON for data storage

_____

### File Management

The application saves tasks in a file named `tasks.json`.

If the file does not exist, it will be created automatically when you add and save tasks.

### Example Usage
```
Task Manager Menu:
1. Add Task
2. View Tasks
3. Update Task
4. Delete Task
5. Search for Task
6. Show Progress
7. Exit
Enter your choice: 1

Enter Task Title: Complete homework
Enter Task Description: Finish math assignments.
Enter Due Date (yyyy-mm-dd): 2025-01-01
Enter Priority (Low, Medium, High): High
Enter Status (Pending, In Progress, Completed): Pending
Enter Category (e.g.: Work, Personal, Study): Study
Task added successfully!
```
