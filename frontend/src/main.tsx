import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import "./index.css";
import Root from "./routes/root";
import ErrorPage from "./error-page";

// Import routes and loaders
import Index, { loader as indexLoader } from "./routes";
import Contact, { loader as contactLoader } from "./routes/contact";
import EditContact, { action as editAction } from "./routes/edit";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Root />,
    errorElement: <ErrorPage />,
    children: [
      {
        index: true,
        loader: indexLoader,
        element: <Index />,
      },
      {
        path: "contacts/:contactId",
        loader: contactLoader,
        element: <Contact />,
      },
      {
        path: "contacts/:contactId/edit",
        loader: contactLoader,
        action: editAction,
        element: <EditContact />,
      },
    ],
  },
  {
    path: "contacts/:contactId",
    element: <Contact />,
  },
]);

ReactDOM.createRoot(document.getElementById("root")!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>
);
