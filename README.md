# Project Name

This is a sample project that demonstrates the usage of a dotnet codespace on GitHub.

## Getting Started

To start development, follow these steps:

1. Clone the repository.
2. Open the repository in a Codespace on GitHub.
3. Install the required dependencies by running `npm install` in the root directory and in `frontend`.
4. Start the development server by running `npm run dev` in the root directory.

## Suggestions for Changes

Here are some changes you can try making to this app:

- Make a change to `Program.cs` or `root.tsx` and see how the app is reloaded.
- Try adding a new property to the Contact class.
- Add a new route to the frontend.

## Connecting to SQL Server

This development environment runs MS SQL Server 2022 in a container. You can find connection details in the `devcontainer.json` file. To connect to the database, you can use the following command:

```bash
sqlcmd -S localhost -U sa -P 'P@ssw0rd'
```

Learn more about the SQL Server container [here](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-ubuntu?view=sql-server-ver16&tabs=ubuntu2204#connect-locally).

Happy coding!
