# Project Name

This is a sample project that demonstrates the usage of a dotnet codespace on GitHub.

## Getting Started

To start development, follow these steps:

1. Clone the repository.
2. Open the repository in a Codespace on GitHub.
3. Install the required dependencies by running `npm install` in the root directory and in `frontend`.
4. Run database migrations by running `npm run db:migrate` in the root directory.
4. Start the development server by running `npm run dev` in the root directory.

## Technologies Used

In this app we're using the following technologies:

- [ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-8.0)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [React](https://reactjs.org/)
- [React Router](https://reactrouter.com/)
- [TypeScript](https://www.typescriptlang.org/)
- [Tailwind CSS](https://tailwindcss.com/)
- [React Testing Library](https://testing-library.com/docs/react-testing-library/intro/)

## Next Steps

Once you've got the app up and running, please take up to 3 hours to explore the codebase and make some changes. There are some suggestions below.

Don't worry if you don't get through all of them, as almost every developer would struggle to do this. We're more interested in how you approach the problem than the final result. We'll go through the rest of the list together in the interview!

## Things to try

Here are some things to try with the app:

1. Get it running locally!
2. Make a change to `Program.cs` or `/routes/index.tsx` and see how the app is reloaded.
3. Try adding a new property to the Contact class.
4. Make deleting a contact work.
5. Add a form to allow you to create a new contact.
6. Add unit tests for the Contact class.
7. Add unit tests for the WebApplication in `Program.cs`
8. Allow you to "favourite" a contact. (HINT: a single button can be a whole form!)
10. Pick a new feature to add!

## Connecting to SQL Server

This development environment runs MS SQL Server 2022 in a container. You can find connection details in the `devcontainer.json` file. To connect to the database, you can use the following command:

```bash
sqlcmd -S localhost -U sa -d ApplicationDB -P 'P@ssw0rd'
```

Learn more about the SQL Server container [here](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-ubuntu?view=sql-server-ver16&tabs=ubuntu2204#connect-locally).

## Trouble Shooting

### If you're unable to access the database
Make sure that you can connect to the database on the command line. If you can't try re-building your container using the VS Code command, "Codespaces: Rebuild Container".

If the database is available it's possible the migrations didn't run properly from the `postCreateCommand` in the `devcontainer.json` file. You can run the migrations manually by running the following commands:

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

Happy coding!
