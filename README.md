
# Test for Searchable

This Task Manager Application is designed to help users organize and manage their tasks efficiently. Below, you'll find information on how to set up and use the application, as well as details on its design choices and features.

## 1. Setup Instructions:

To set up the Task Manager Application, follow these steps:

- Clone the repository to your local machine.

- Ensure you have a compatible environment with necessary dependencies installed (EntityFrameWork core, SQL server, EntityFrameWork core tool).
- Set up the database by executing the SQL script provided in the database_setup.sql file. 
- Make sure to adjust the database configuration in the application accordingly.
- Configure the application settings, such as database connection details, in the config file.
- Run the application and navigate to the designated URL in your web browser.

## 2. Usage:
Once the application is set up, users can perform the following tasks:
- Create, read, update, and delete tasks, users, and categories.
- Sort and paginate through users.

## 3. Design Choices:
The application follows the Model-View-Controller (MVC) architectural pattern to ensure a separation of concerns and maintainability:
- Model: Data modeling is done using tables like Task, User, and Category, with appropriate relationships defined.
- View: The user interface allows users to interact with the application and view their tasks, users, and categories.
- Controller: CRUD operations, validation, sorting, searching, pagination funtionality are implemented in controller actions and service methods.


## Tech Stack

**Client:** Html, CSS:Bootstraps for styling.

**Server:** Asp.Net core MVC, Enttity Framework core, SQL server.

