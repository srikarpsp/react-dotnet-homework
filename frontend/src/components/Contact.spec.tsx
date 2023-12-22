import { render, screen } from "@testing-library/react";
import { ContactType } from "../types";
import Contact from "./Contact";
import { ReactNode } from "react";

jest.mock("react-router-dom", () => ({
  Link: ({ children }: { children: ReactNode }) => (
    <div data-testid="mock-link">{children}</div>
  ),
}));

describe("<Contact />", () => {
  const contact: ContactType = {
    id: 1,
    name: "John Doe",
    email: "john@doe.com",
    phone: "1234567890",
    avatar: "/avatars/headshot_0.png",
    twitter: "johndoe",
    notes: "Note about John Doe",
  };

  it("renders name", async () => {
    render(<Contact contact={contact} />);

    const item = await screen.getByText(contact.name);

    expect(item).not.toBeNull();
  });

  it("renders email", async () => {
    render(<Contact contact={contact} />);

    const item = await screen.getByText(contact.email);

    expect(item).not.toBeNull();
  });

  it("renders phone", async () => {
    render(<Contact contact={contact} />);

    const item = await screen.getByText(contact.phone);

    expect(item).not.toBeNull();
  });
});
